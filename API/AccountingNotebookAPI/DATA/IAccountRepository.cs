using AccountingNotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DATA
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync();
        Account GetAccount();
    }
}
