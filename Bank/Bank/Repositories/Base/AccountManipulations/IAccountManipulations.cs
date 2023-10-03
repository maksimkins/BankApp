using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.Base.AccountManipulations;

public interface IAccountManipulations
{
    public void AddToAccount(int id);
    public void DeductToAccount(int id);
    public void TransferAccount(int id, int idToTransfer);
}
