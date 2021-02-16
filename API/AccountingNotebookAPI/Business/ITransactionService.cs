using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Business
{
    public interface ITransactionService
    {
        TransactionReponses AddTransaction(TransactionForAddDTO newTransaction);
        Task<PagedList<TransactionForListDTO>> GetTransactions(PageParams pageParams);
        Task<TransactionDetailDTO> GetTransactionDetail(int id);
    }
}
