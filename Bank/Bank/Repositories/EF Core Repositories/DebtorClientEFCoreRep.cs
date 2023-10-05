﻿using Bank.Models;
using Bank.Repositories.Base;
using Bank.Repositories.EF_Core_Repositories.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.EF_Core_Repositories;

public class DebtorClientEFCoreRep : IDebtorClientRep
{
    private readonly AllClientsDbContext context;

    public DebtorClientEFCoreRep()
    {
        context = new AllClientsDbContext();
    }

    public void Add(DebtorClient client)
    {
        context.DebtorClients.Add(client);
        this.context.SaveChanges();
    }

    public IEnumerable<DebtorClient> GetAll() => context.DebtorClients.ToList();

    public DebtorClient GetById(int id) 
    {
        LoanClient? loanclient = context.LoanClients.FirstOrDefault(c => c.ClientId == id)
            ?? throw new Exception("there is no such user");

        return context.DebtorClients.FirstOrDefault(d => d.LoanClientId == loanclient.Id) 
            ?? throw new Exception("there is no such user"); 
    }
    public int GetIdByLoginPassword(string login, string password)
    {
        Client client = context.Clients.FirstOrDefault(c => c.Login == login && c.Password == password)
            ?? throw new Exception("there is no such user");

        LoanClient loanclient = context.LoanClients.FirstOrDefault(l => l.ClientId == client.Id)
            ?? throw new Exception("there is no such user");

        DebtorClient debtorclient = context.DebtorClients.FirstOrDefault(d => d.LoanClientId == loanclient.Id)
            ?? throw new Exception("there is no such user");


        return debtorclient.Id;
    }

    public void PayForDebt(int id, double payment)
    {
        DebtorClient? debtor = GetById(id);

        if (payment != debtor.DebtToReturn)
            throw new Exception("wrong amount of money");

        context.DebtorClients.Remove(debtor);

        context.SaveChanges();
    }
}