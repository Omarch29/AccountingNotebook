using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DTOs
{
    public class TransactionDetailDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double BalanceAmount { get; set; }
        public double CreditBalance { get; set; }
    }
}
