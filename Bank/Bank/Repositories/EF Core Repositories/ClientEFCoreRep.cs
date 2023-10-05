using Bank.Models;
using Bank.Repositories.Base;
using Bank.Repositories.EF_Core_Repositories.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.EF_Core_Repositories;

public class ClientEFCoreRep : IClientRep
{
    private readonly AllClientsDbContext context;

    public ClientEFCoreRep()
    {
        context = new AllClientsDbContext();
    }

    public void Add(Client client)
    {
        context.Clients.Add(client);
        this.context.SaveChanges();
    }

    public void AddToAccount(int id, double money)
    {
        Client? client = this.GetById(id);

        if (client is not null)
            client.Account += money;

        this.context.SaveChanges();
    }

    public void DeductToAccount(int id, double money)
    {
        Client? client = this.GetById(id);

        if (client is not null)
            client.Account -= money;

        money = money < 0 ? throw new Exception("user hasn't got enough money") : money;

        this.context.SaveChanges();
    }

    public IEnumerable<Client> GetAll() => context.Clients.ToList();

    public Client GetById(int id) => 
        context.Clients.FirstOrDefault(c => c.Id == id) 
        ?? throw new Exception("there is no such user");

    public int GetIdByLoginPassword(string login, string password) => 
        context.Clients.FirstOrDefault(c => c.Login == login && c.Password == password)?.Id 
        ?? throw new Exception("there is no such user");

    public void TransferAccount(int idHost, int idToTransfer, double money)
    {
        Client? host = GetById(idHost);
        

        if (host == null)
            throw new Exception("there is no such sender");

        Client? toTransfer = GetById(idToTransfer);

        if (toTransfer == null)
            throw new Exception("there is no such receiver");

        host.Account -= money > host.Account ? throw new Exception("not enough money") : money;
        toTransfer.Account += money;

        this.context.SaveChanges();
    }
}
