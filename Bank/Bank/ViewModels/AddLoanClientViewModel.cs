using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels;
using Bank.Command;
using Bank.Repositories.Base;
using Bank.ViewModels.Base;
using System.Windows;

class AddLoanClientViewModel : ViewModelBase
{
    private ILoanClientRep lcrep;

    public AddLoanClientViewModel(ILoanClientRep lcrep) { this.lcrep = lcrep; }

    private string? clientId;

    public string? ClientId
    {
        get => clientId;
        set
        {
            base.PropertyChangeMethod(out clientId, value);
        }
    }

    private string? percentes;

    public string? Percentes
    {
        get => percentes;
        set
        {
            base.PropertyChangeMethod(out percentes, value);
        }
    }

    private string? monthDuration;

    public string? MonthDuration
    {
        get => monthDuration;
        set
        {
            base.PropertyChangeMethod(out monthDuration, value);
        }
    }

    private string? loan;

    public string? Loan
    {
        get => loan;
        set
        {
            base.PropertyChangeMethod(out loan, value);
        }
    }


    private Command commandToReturn;
    public Command CommandReturn => this.commandToReturn ??= new Command(
    execute: () => {
        try
        {
            App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<HomeViewModel>();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


    },
    canExecute: () => true);

    private Command commandAddLoanClient;

    public Command CommandAddLoanClient => this.commandAddLoanClient ??= new Command(
    execute: () => {
        try
        {
            if (!int.TryParse(Percentes, out int percentes) || !int.TryParse(MonthDuration, out int monthDuration) || !int.TryParse(ClientId, out int clientid) || !double.TryParse(Loan, out double l))
                throw new Exception("credentials error");

            lcrep.Add(new Models.LoanClient() { Perecents = percentes, MonthDuration = monthDuration, ClientId = clientid,  Loan = l, LoanGotDate = DateTime.Now, Month = 0, PaidPartOfLoan = 0});
            MonthDuration = "";
            Percentes = "";
            ClientId = "";
            Loan = "";
            MessageBox.Show("succesfully added");

            App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<HomeViewModel>();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


    },
    canExecute: () => true);
}
