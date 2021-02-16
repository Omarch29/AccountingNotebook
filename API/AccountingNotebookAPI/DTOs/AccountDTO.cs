using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public double AvailableCreditBalance { get; set; }
        public double MaxCreditBalance { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
