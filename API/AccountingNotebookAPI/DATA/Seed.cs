using AccountingNotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DATA
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;

        }
        public void SeedEntities()
        {
            if (_context.Accounts.Count() > 0) return;

            var exampleAccount = new Account()
            {
                Id = 1,
                Balance = 98.5d,
                AvailableCreditBalance = 195,
                MaxCreditBalance = 200,
                FirstName = "Omar",
                LastName = "Chahdi",
                BirthDate = (DateTime.Now).AddYears(-28)
            };

            _context.Accounts.Add(exampleAccount);

            var exampleTransactions = new Transaction[]
            {
                new Transaction {Id = 1, Amount = -4d, BalanceAmount=96, CreditBalance=200, EffectiveDate=DateTime.Now, Type=TransactionType.debit },
                new Transaction {Id = 2, Amount = -5d, BalanceAmount=91, CreditBalance=200, EffectiveDate=DateTime.Now, Type=TransactionType.debit },
                new Transaction {Id = 3, Amount = -1d, BalanceAmount=91, CreditBalance=199, EffectiveDate=DateTime.Now, Type=TransactionType.credit },
                new Transaction {Id = 4, Amount = -2.5d, BalanceAmount=88.5d,CreditBalance=199, EffectiveDate=DateTime.Now, Type=TransactionType.debit },
                new Transaction {Id = 5, Amount = -4d, BalanceAmount=88.5d, CreditBalance=195, EffectiveDate=DateTime.Now, Type=TransactionType.credit },
                new Transaction {Id = 6, Amount = 10d, BalanceAmount=98.5d, CreditBalance=195 ,EffectiveDate=DateTime.Now, Type=TransactionType.debit },
            };

            _context.Transactions.AddRange(exampleTransactions);
            _context.SaveChanges();
        }
    }
}
