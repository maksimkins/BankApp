using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base;

public interface ILoanClientRep
{
    public IEnumerable<LoanClient> GetAll();
    public LoanClient GetById(int id);
    public void Add(LoanClient client);
    public void PayForLoan(int id, double payment);
    public int GetIdByLoginPassword(string login, string password);
    public Client ReturnAsClient(int id);
    public IEnumerable<Client> ReturAllnAsClient();
    public void DeleteById(int loanId);
}
