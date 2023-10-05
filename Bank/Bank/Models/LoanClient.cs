using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class LoanClient // delete from table if Loan == PaidPartOfLoan
    {
        [Key]
        public int Id { get; set; }
        public double Loan { get; set; }
        public double PaidPartOfLoan { get; set; }
        public int Month { get; set; }
        public int Perecents { get; set; } // 20 15 12 %
        public int MonthDuration { get; set; } // +6 +12 +24 month
        public DateTime LoanGotDate { get; set; } // DateTime.Now.Month - LoanGotDate.Month > Month => Become.Debtor;

        //[ForeignKey("Clients")]
        public int ClientId { get; set; }      
        public Client Client { get; set; }

        public bool MustPayForThisMonth() => (DateTime.Now.Month - LoanGotDate.Month) == 0;
    }
}
