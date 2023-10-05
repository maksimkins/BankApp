using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models;

public class DebtorClient
{
    [Key]
    public int Id {  get; set; } 
    public double DebtToReturn { get; set; } = 0; // высчитывается при создании объекта

    public int LoanClientId { get; set; }
    public LoanClient LoanClient { get; set; }

    
    //public DebtorClient()
    //{
    //    this.DebtToReturn += (base.Loan - base.PaidPartOfLoan);
    //    this.DebtToReturn += (base.Loan - base.PaidPartOfLoan) * base.Perecents / 100;
    //    this.DebtToReturn += this.DebtToReturn * 5;
    //}
}
