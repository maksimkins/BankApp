﻿using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base;

public interface ILoanClientRep
{
    const string connectionstring = "Server=localhost;Database=BankDb;Trusted_Connection=True;";

    public IEnumerable<LoanClient> GetAll();
    public LoanClient GetById(int id);
    public void Add(LoanClient client);
    public void PayForLoan(int id, decimal payment);
}