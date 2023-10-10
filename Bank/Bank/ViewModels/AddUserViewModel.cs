using Bank.Repositories.Base;
using Bank.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels;
using Bank.Command;
using System.Windows;

class AddUserViewModel : ViewModelBase
{
    private IClientRep clientRep;

    public AddUserViewModel(IClientRep clientRep) { this.clientRep = clientRep; }

    private string? login;

    public string? Login
    {
        get => login;
        set
        {
            base.PropertyChangeMethod(out login, value);
        }
    }

    private string? password;

    public string? Password
    {
        get => password;
        set
        {
            base.PropertyChangeMethod(out password, value);
        }
    }

    private string? account;

    public string? Account
    {
        get => account;
        set
        {
            base.PropertyChangeMethod(out account, value);
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

    private Command commandAddUser;

    public Command CommandAddUser => this.commandAddUser ??= new Command(
    execute: () => {
        try
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || Login.Length > 25 || Password.Length > 25 || !double.TryParse(Account, out double ac))
                throw new Exception("credentials error");

            clientRep.Add(new Models.Client() { Login = Login, Password = Password, Account = ac});
            Login = "";
            Password = "";
            Account = "";
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
