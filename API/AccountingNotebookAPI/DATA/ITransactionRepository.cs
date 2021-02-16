using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Helpers;
using AccountingNotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DATA
{
    public interface ITransactionRepository
    {
        bool AddTransaction(Account accountData, TransactionForAddDTO Transaction);
        Task<Transaction> GetTransaction(int id);
        Task<PagedList<Transaction>> GetAll(int pageNumber = 1, int pageSize = 10);
    }
}
