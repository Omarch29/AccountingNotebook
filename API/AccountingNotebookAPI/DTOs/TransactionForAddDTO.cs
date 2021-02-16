using AccountingNotebookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.DTOs
{
    public class TransactionForAddDTO
    {
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
    }
}
