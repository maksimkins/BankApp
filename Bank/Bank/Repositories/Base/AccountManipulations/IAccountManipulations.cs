using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base.AccountManipulations;

public interface IAccountManipulations
{
    public void AddToAccount(int id, double money);
    public void DeductToAccount(int id, double money);
    public void TransferAccount(int idHost, int idToTransfer, double money);
}
