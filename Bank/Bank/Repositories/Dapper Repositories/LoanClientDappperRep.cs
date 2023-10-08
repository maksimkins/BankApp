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
        this.con = new SqlConnection("Server=localhost;Database=Bank;Integrated Security=SSPI;TrustServerCertificate=True");
        this.con.Open();
    }
    public void Add(LoanClient client)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LoanClient> GetAll()
    {
        throw new NotImplementedException();
    }

    public LoanClient GetById(int id) => con.QueryFirstOrDefault<LoanClient>("select * LoanClients lc where lc.Id = @id", id) 
        ?? throw new Exception("there is no such user");

    public int GetIdByLoginPassword(string login, string password)
    {
        throw new NotImplementedException();
    }

    public void PayForLoan(int id, double payment)
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
