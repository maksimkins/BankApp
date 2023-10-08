using Bank.Models;
using Bank.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Dapper_Repositories;

public class DebtorClientDapperRep : IDebtorClientRep
{
    public void Add(DebtorClient client)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DebtorClient> GetAll()
    {
        throw new NotImplementedException();
    }

    public DebtorClient GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int GetIdByLoginPassword(string login, string password)
    {
        throw new NotImplementedException();
    }

    public void PayForDebt(int id, double payment)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Client> ReturAllnAsClient()
    {
        throw new NotImplementedException();
    }

    public Client ReturnAsClient(int id)
    {
        throw new NotImplementedException();
    }
}
