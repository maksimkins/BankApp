using Bank.Models;
using Bank.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Dapper_Repositories;

public class LoanClientDappperRep : ILoanClientRep
{
    private SqlConnection con;

    public LoanClientDappperRep()
    {
        this.con = new SqlConnection("Server=localhost;User Id=admin;Password=admin;Database=Bank;TrustServerCertificate=True");
        this.con.Open();
    }
    public void Add(LoanClient client)
    {

        DynamicParameters parameter = new DynamicParameters();

        parameter.Add("@PaidPartOfLoan", client.PaidPartOfLoan);
        parameter.Add("@Month", client.Month);
        parameter.Add("@Loan", client.Loan);
        parameter.Add("@ClientId", client.ClientId);
        parameter.Add("@LoanGotDate", client.LoanGotDate);
        parameter.Add("@MonthDuration", client.MonthDuration);
        parameter.Add("@Perecents", client.Perecents);

        string command = @"insert into LoanClient values (@PaidPartOfLoan, @Month, @Loan, @ClientId, @LoanGotDate, @MonthDuration, @Perecents)";

        con.Execute(command, parameter);
    }

    public void DeleteById(int loanId)
    {

        string command = @"delete on LoanClients where Id = @id";

        this.con.Execute(command, loanId);
    }

    public IEnumerable<LoanClient> GetAll() => this.con.Query<LoanClient>("select * from LoanClients");

    public LoanClient GetById(int id) => con.QueryFirstOrDefault<LoanClient>("select * LoanClients lc where lc.Id = @id", id) 
        ?? throw new Exception("there is no such user");

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
            con.Execute("delete from LoanClients where Id = @id", id);
    }

    public IEnumerable<Client> ReturAllnAsClient()
    {

        List<Client> list = new List<Client>();

        foreach (var lc in this.GetAll())
        {
            Client c = con.QueryFirstOrDefault<Client>("select * from Clients c where c.Id = @id", lc.ClientId);
            list.Add(c);
        }

        return list;
    }

    public Client ReturnAsClient(int id)
    {
        LoanClient dc = this.GetById(id);
        return this.con.QueryFirstOrDefault<Client>("select * from Clients c where c.Id = @id", dc.ClientId);
    }
}
