using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Models
{
    public enum TransactionType: int 
    { 
        credit = 1,
        debit = 2
    }

    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double BalanceAmount { get; set; }
        public double CreditBalance { get; set; }
    }
}
