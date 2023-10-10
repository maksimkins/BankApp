using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base;

public interface IDebtorClientRep
{
    public IEnumerable<DebtorClient> GetAll();
    public DebtorClient GetById(int id);
    public void Add(DebtorClient client);
    public void PayForDebt(int id, double payment);
    public int GetIdByLoginPassword(string login, string password);
    public Client ReturnAsClient(int id);
    public IEnumerable<Client> ReturAllnAsClient();
    public void DeleteById(int debtorId);
}
