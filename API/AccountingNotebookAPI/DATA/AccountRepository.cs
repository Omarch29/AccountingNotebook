using AccountingNotebookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DATA
{
    public class AccountRepository: IAccountRepository
    {
        private readonly DataContext _context;
        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountAsync() {
            return await _context.Accounts.FirstOrDefaultAsync();
        }

        public Account GetAccount()
        {
            return _context.Accounts.FirstOrDefault();
        }


    }
}
