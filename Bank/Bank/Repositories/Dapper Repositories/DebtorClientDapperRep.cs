using Bank.Models;
using Bank.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Dapper_Repositories;

public class DebtorClientDapperRep : IDebtorClientRep
{
    private SqlConnection con;

    public DebtorClientDapperRep()
    {
        this.con = new SqlConnection("Server=localhost;User Id=admin;Password=admin;Database=Bank;TrustServerCertificate=True");
        this.con.Open();
    }

    public void Add(DebtorClient client)
    {

        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@debttoreturn", client.DebtToReturn);
        parameter.Add("@clientid", client.ClientId);

        string command = @"insert into DebtorClients values (@debttoreturn, @clientid)";

        con.Execute(command, parameter);
    }

    public void DeleteById(int debtorId)
    {
        string command = @"delete on DebtorClients where Id = @id";

        this.con.Execute(command, debtorId);
    }

    public IEnumerable<DebtorClient> GetAll()
    {
        return con.Query<DebtorClient>("select * from DebtorClients");
    }

    public DebtorClient GetById(int id) => con.QueryFirstOrDefault<DebtorClient>(@"select * from DebtorClients dc where dc.Id = @id", id)
        ?? throw new Exception("there is no such user");

    public int GetIdByLoginPassword(string login, string password)
    {
        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@login", login);
        parameter.Add("@password", password);

        Client client = con.QueryFirstOrDefault<Client>("select * from Clients c where c.Login = @login and c.Password = @password", parameter)
            ?? throw new Exception("there is no such user");

        return this.GetById(client.Id).Id;
    }

    public void PayForDebt(int id, double payment)
    {
        DebtorClient dc = this.GetById(id);

        if (payment < dc.DebtToReturn)
            throw new Exception("not enough money");

        string command = @"delete on DebtorClients where Id = @id";

        con.Execute(command, id);
    }

    public IEnumerable<Client> ReturAllnAsClient()
    {
        List<Client> list = new List<Client>();

        foreach(var dc in this.GetAll())
        {
            Client c = con.QueryFirstOrDefault<Client>("select * from Clients c where c.Id = @id", dc.ClientId);
            list.Add(c);
        }

        return list;
    }

    public Client ReturnAsClient(int id)
    {
        DebtorClient client = this.GetById(id);

        return con.QueryFirstOrDefault<Client>("select * Clients c where c.Id = @id", client.ClientId);
    }
}
