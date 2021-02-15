using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public double AvailableCreditBalance { get; set; }
        public double MaxCreditBalance { get; set; }
        public DateTime BirthDate { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.Date > BirthDate.Date) age++;
                return age;
            }
        }

        // Reference
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
