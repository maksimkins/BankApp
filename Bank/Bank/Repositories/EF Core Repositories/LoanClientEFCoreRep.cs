using Bank.Models;
using Bank.Repositories.Base;
using Bank.Repositories.EF_Core_Repositories.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.EF_Core_Repositories;

public class LoanClientEFCoreRep : ILoanClientRep
{
    private readonly AllClientsDbContext context;

    public LoanClientEFCoreRep()
    {
        context = new AllClientsDbContext();
    }

    public void Add(LoanClient client)
    {
        context.LoanClients.Add(client);
        this.context.SaveChanges();
    }

    public IEnumerable<LoanClient> GetAll() => context.LoanClients.ToList();

    public LoanClient GetById(int id) => 
        context.LoanClients.FirstOrDefault(c => c.ClientId == id) 
        ?? throw new Exception("there is no such user");

    public int GetIdByLoginPassword(string login, string password) => 
        context.Clients.FirstOrDefault(c => c.Login == login && c.Password == password)?.Id 
        ?? throw new Exception("there is no such user");
    

    public void PayForLoan(int id, double payment)
    {
        LoanClient client = this.GetById(id);

        if (client is null)
            throw new Exception("there is no such loaner");

        if (!client.MustPayForThisMonth())
            throw new Exception("no need to pay");

        if (payment != (client.Loan / client.MonthDuration) * (client.Perecents + 1))
            throw new Exception("not correct amount of money");

        client.PaidPartOfLoan += payment;

        if (client.PaidPartOfLoan >= client.Loan)
            context.LoanClients.Remove(client);

        context.SaveChanges();
    }

    public IEnumerable<Client> ReturAllnAsClient()
    {
        throw new NotImplementedException();
    }

    public Client ReturnAsClient(int id)
    {
        LoanClient lc = this.GetById(id);
        return context.Clients.First(c => c.Id == lc.ClientId);
    }
}
