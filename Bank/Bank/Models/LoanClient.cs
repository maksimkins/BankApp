using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class LoanClient: Client // delete from table if Loan == PaidPartOfLoan
    {
        public decimal Loan { get; set; }
        public decimal PaidPartOfLoan { get; set; }
        public int Month { get; set; }
        public int Perecents { get; set; } // 20 15 12 %
        public DateTime Deadline { get; set; } // +6 +12 +24 month
        public DateTime PeriodOfPayment { get; set; } // 1 month
    }
}
