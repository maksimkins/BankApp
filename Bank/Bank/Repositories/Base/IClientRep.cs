using Bank.Models;
using Bank.Repositories.Base.AccountManipulations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base;

public interface IClientRep : IAccountManipulations
{
    public IEnumerable<Client> GetAll();
    public Client GetById(int id);
    public void Add(Client client);
}
