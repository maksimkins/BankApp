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

    public void DeleteById(int loanId)
    {

        LoanClient lc = this.GetById(loanId);

        context.LoanClients.Remove(lc);

        context.SaveChanges();
    }

    public IEnumerable<LoanClient> GetAll() => context.LoanClients.ToList();

    public LoanClient GetById(int id) => 
        context.LoanClients.FirstOrDefault(c => c.Id == id) 
        ?? throw new Exception("there is no such user");

    public int GetIdByLoginPassword(string login, string password)
    {
        int? id = (context.Clients.FirstOrDefault(c => c.Login == login && c.Password == password)?.Id);

        if(id is null) throw new Exception("there is no such user");
        

        return context.LoanClients.FirstOrDefault(lc => lc.ClientId == id)?.Id
         ?? throw new Exception("there is no such user");
               
    }


    public void PayForLoan(int id, double payment)
    {
        LoanClient client = this.GetById(id);

        if (client is null)
            throw new Exception("there is no such loaner");

        if (!client.MustPayForThisMonth())
            throw new Exception("no need to pay");

        if (payment != (Math.Round((client.Loan / client.MonthDuration) * (client.Perecents/100 + 1))) )
            throw new Exception("not correct amount of money");

        client.PaidPartOfLoan += payment;
        client.Month += 1;

        context.LoanClients.Update(client);

        if (client.PaidPartOfLoan >= client.Loan)
            context.LoanClients.Remove(client);

        context.SaveChanges();
    }

    public IEnumerable<Client> ReturAllnAsClient()
    {

        List<Client> list = new List<Client>();

        foreach (var dc in this.GetAll())
        {
            Client c = this.ReturnAsClient(dc.Id);
            list.Add(c);
        }

        return list;
    }

    public Client ReturnAsClient(int id)
    {
        LoanClient lc = this.GetById(id);
        return context.Clients.First(c => c.Id == lc.ClientId);
    }
}
