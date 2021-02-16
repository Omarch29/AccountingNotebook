using AccountingNotebookAPI.DATA;
using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Helpers;
using AccountingNotebookAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Business
{
    public enum TransactionReponses
    {
        ok,
        insufficientfunds,
        exceedTheLimit,
        insufficientCredit,
        error
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            this.accountRepository = accountRepository;
            _mapper = mapper;
        }

        public TransactionReponses AddTransaction(TransactionForAddDTO newTransaction)
        {
            var accountData = accountRepository.GetAccount();
            if (accountData == null) return TransactionReponses.error;

            if (newTransaction.Type == TransactionType.credit)
            {
                if (newTransaction.Amount > accountData.MaxCreditBalance) return TransactionReponses.exceedTheLimit;

                if ((accountData.AvailableCreditBalance - newTransaction.Amount) < 0) return TransactionReponses.insufficientCredit;
            }
            else
            {
                if ((accountData.Balance - newTransaction.Amount) < 0) return TransactionReponses.insufficientfunds;
            }

            newTransaction.Amount = newTransaction.Amount * (-1);
            if (transactionRepository.AddTransaction(accountData, newTransaction)) return TransactionReponses.ok;
            else return TransactionReponses.error;

        }

        public async Task<PagedList<TransactionForListDTO>> GetTransactions(PageParams pageParams) {

            var transactions = await transactionRepository.GetAll(pageParams.PageNumber, pageParams.PageSize);
            var response = _mapper.Map<PagedList<TransactionForListDTO>>(transactions);
            response.CurrentPage = transactions.CurrentPage;
            response.PageSize = transactions.PageSize;
            response.TotalPages = transactions.TotalPages;
            response.TotalCount = transactions.TotalCount;
            return response;
        }

        public async Task<TransactionDetailDTO> GetTransactionDetail(int id) {
            var transaction = await transactionRepository.GetTransaction(id);
            return _mapper.Map<TransactionDetailDTO>(transaction);
        }



    }
}
