using Bank.Models;
using Bank.Repositories.Base;
using Bank.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace Bank.ViewModels;
using Bank.Command;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase? activeViewModel;

    public ViewModelBase? ActiveViewModel
    {
        get => activeViewModel;
        set 
        {
            this.RenewClients();
            this.RenewDebtors();
            this.RenewLoanClients();
            this.CheckLoaners();
            base.PropertyChangeMethod(out activeViewModel, value);
        } 
    }

    private IClientRep clientRep;
    private IDebtorClientRep debtroClientRep;
    private ILoanClientRep loanClientRep;

    private Command payForLoan;
    public Command PayForLoan => this.payForLoan ??= new Command(
          execute: () => {
              this.ActiveViewModel = App.Container.GetInstance<PayForLoanViewModel>();
              this.RenewClients();
              this.RenewDebtors();
              this.RenewLoanClients();

          },
          canExecute: () => true);

    private Command payForDebt;
    public Command PayForDebt => this.payForDebt ??= new Command(
          execute: () => {
              this.ActiveViewModel = App.Container.GetInstance<PayfordebtViewModel>();
              this.RenewClients();
              this.RenewDebtors();
              this.RenewLoanClients();

          },
          canExecute: () => true);



    private Command transfer;
    public Command Transfer => this.transfer ??= new Command(
          execute: () => {
              this.ActiveViewModel = App.Container.GetInstance<TransferViewModel>();
              this.RenewClients();
              this.RenewDebtors();
              this.RenewLoanClients();

          },
          canExecute: () => true);


    private Command addUser;
    public Command AddUser => this.addUser ??= new Command(
          execute: () => {
              this.ActiveViewModel = App.Container.GetInstance<AddUserViewModel>();
              this.RenewClients();
              this.RenewDebtors();
              this.RenewLoanClients();

          },
          canExecute: () => true);

    private Command addLoanClient;
    public Command AddLoanClient => this.addLoanClient ??= new Command(
          execute: () => {
              this.ActiveViewModel = App.Container.GetInstance<AddLoanClientViewModel>();
              this.RenewClients();
              this.RenewDebtors();
              this.RenewLoanClients();

          },
          canExecute: () => true);

    


    public MainViewModel(IClientRep clientRep, IDebtorClientRep debtroClientRep, ILoanClientRep loanClientRep)
    {
        this.clientRep = clientRep;
        this.debtroClientRep = debtroClientRep;
        this.loanClientRep = loanClientRep;

        this.RenewClients();
        this.RenewDebtors();
        this.RenewLoanClients();
    }

    private void CheckLoaners()
    {
        IEnumerable<LoanClient> loaners = loanClientRep.GetAll();

        foreach(var loaner in loaners)
        {
            if (loaner.IsDebtor())
            {
                loanClientRep.DeleteById(loaner.Id);
                DebtorClient dc = new DebtorClient();

                dc.DebtToReturn += (loaner.Loan - loaner.PaidPartOfLoan);
                dc.DebtToReturn += (loaner.Loan - loaner.PaidPartOfLoan) * loaner.Perecents / 100; ;
                dc.DebtToReturn += dc.DebtToReturn * 5;

                dc.ClientId = loaner.ClientId;  

                debtroClientRep.Add(dc);
            }
        }

        this.RenewDebtors();
        this.RenewLoanClients();
    }

    private ObservableCollection<Client> debtorClient = new ObservableCollection<Client>();

    public ObservableCollection<Client> DebtorClients
    {
        get { return debtorClient; }
        set { 
            base.PropertyChangeMethod(out debtorClient, value);

        }
    }

    private ObservableCollection<Client> clients = new ObservableCollection<Client>();

    public ObservableCollection<Client> Clients
    {
        get { return clients; }
        set
        {
            base.PropertyChangeMethod(out clients, value);

        }
    }

    private ObservableCollection<Client> loanClients = new ObservableCollection<Client>();

    public ObservableCollection<Client> LoanClients
    {
        get { return loanClients; }
        set
        {
            base.PropertyChangeMethod(out loanClients, value);

        }
    }

    // public List<Client> Clients { set; get; } = new List<Client>();
    //public List<Client> LoanClients { set; get; } = new List<Client>();
    //public List<Client> DebtorClients { set; get; } = new List<Client>();

    private void RenewClients()
    {
        Clients.Clear();
        IEnumerable<Client> cls = this.clientRep.GetAll();

        foreach (var item in cls)
        {
            Clients.Add(item);
        }
    }

    private void RenewDebtors()
    {
        DebtorClients.Clear();
        IEnumerable<Client> cls = this.debtroClientRep.ReturAllnAsClient();

        foreach (var item in cls)
        {
            DebtorClients.Add(item);
        }
    }

    private void RenewLoanClients()
    {
        LoanClients.Clear();
        IEnumerable<Client> cls = this.loanClientRep.ReturAllnAsClient();

        foreach (var item in cls)
        {
            LoanClients.Add(item);
        }
    }
}
