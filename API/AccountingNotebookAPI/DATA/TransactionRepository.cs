using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Helpers;
using AccountingNotebookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AccountingNotebookAPI.DATA
{


    public class TransactionRepository : ITransactionRepository
    {

        private readonly DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<PagedList<Transaction>> GetAll(int pageNumber = 1, int pageSize= 10)
        {
            var query = _context.Transactions;
            return await PagedList<Transaction>.CreateAsync(query, pageNumber, pageSize);
        }

        public bool AddTransaction(Account accountData, TransactionForAddDTO Transaction) {

            if (Transaction.Type == TransactionType.debit)
            {
                accountData.Balance += Transaction.Amount;
            }
            else {
                accountData.AvailableCreditBalance += Transaction.Amount;
            }

            var newTransaction = new Transaction()
            {
                Amount = Transaction.Amount,
                BalanceAmount = accountData.Balance,
                CreditBalance = accountData.AvailableCreditBalance,
                EffectiveDate = DateTime.Now,
                Type = Transaction.Type,
                AccountId = accountData.Id

            };
                                    
            _context.Add(newTransaction);
            return _context.SaveChanges() > 0;
        }


    }
}
