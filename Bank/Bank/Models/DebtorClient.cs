using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models;

public class DebtorClient : LoanClient
{
    public decimal DebtToReturn { get; set; } = 0;

    public DebtorClient()
    {
        this.DebtToReturn += (base.Loan - base.PaidPartOfLoan);
        this.DebtToReturn += (base.Loan - base.PaidPartOfLoan) * base.Perecents / 100;
        this.DebtToReturn += this.DebtToReturn * 5;
    }
}
