using Bank.Models;
using Bank.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Dapper_Repositories;

public class ClientDapperRep : IClientRep
{
    private SqlConnection con;

    public ClientDapperRep()
    {
        this.con = new SqlConnection("Server=localhost;User Id=admin;Password=admin;Database=Bank;TrustServerCertificate=True");
        this.con.Open();
    }
    public void Add(Client client)
    {
        string command = @"insert into Clients values (@login, @password, @account)";

        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@login", client.Login);
        parameter.Add("@password", client.Password);
        parameter.Add("@account", client.Account);

        try
        {
            con.Execute(command, param: parameter);
        }
        catch (Exception)
        {
            throw new Exception("user with this login is already existed");
        }
        
    }

    public void AddToAccount(int id, double money)
    {
        string command = @"update Clients set
                           Account = @money + Account
                           where Id = @id";

        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@money", money);
        parameter.Add("@id", id);

        
        int rowsAffected = con.Execute(command, param: parameter);
        if (rowsAffected == 0)
            throw new ArgumentException("there is no such user");
      
    }

    public void DeductToAccount(int id, double money)
    {
        Client client = this.GetById(id);

        if(client.Account < money)
            throw new Exception("client has not enough money");

        string command = @"update Clients set
                           Account = Account - @money
                           where Id = @id";

        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@money", money);
        parameter.Add("@id", id);

        con.Execute(command, parameter);
    }

    public IEnumerable<Client> GetAll() => con.Query<Client>("select * from Clients");

    public Client GetById(int id) => con.QueryFirstOrDefault<Client>("select * from Clients where Clients.Id = @id", id) 
        ?? throw new ArgumentException("there is no such user");

    public int GetIdByLoginPassword(string login, string password)
    {
        string command = "select Id from Clients c where c.Login = @login and c.Password = @password";

        DynamicParameters parameter = new DynamicParameters();
        parameter.Add("@login", login);
        parameter.Add("@password", password);

        try
        {
            int id = con.ExecuteScalar<int>(command, param: parameter);
            return id;
        }
        catch (Exception)
        {
            throw new Exception("there is no such user");
        }
    }

    public void TransferAccount(int idHost, int idToTransfer, double money)
    {
        this.DeductToAccount(idHost, money);
        this.AddToAccount(idToTransfer, money);
    }
}
