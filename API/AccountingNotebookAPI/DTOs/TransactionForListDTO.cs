using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DTOs
{
    public class TransactionForListDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
    }
}
