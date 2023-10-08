using Bank.Models;
using Bank.Repositories.Base;
using Bank.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? activeViewModel;

    public ViewModelBase? ActiveViewModel
    {
        get => activeViewModel;
        set 
        {
            base.PropertyChangeMethod(out activeViewModel, value);
        } 
    }

    private IClientRep clientRep;
    private IDebtorClientRep debtroClientRep;
    private ILoanClientRep loanClientRep;

    public MainViewModel(IClientRep clientRep, IDebtorClientRep debtroClientRep, ILoanClientRep loanClientRep)
    {
        this.clientRep = clientRep;
        this.debtroClientRep = debtroClientRep;
        this.loanClientRep = loanClientRep;
    }

    public ObservableCollection<Client> Clients { set; get; }
    public ObservableCollection<Client> LoanClients { set; get; }
    //public ObservableCollection<Client> Clients { set; get; }


}
