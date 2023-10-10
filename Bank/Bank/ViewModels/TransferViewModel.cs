using Bank.Repositories.Base;
using Bank.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels;
using Bank.Command;
using Bank.Models;
using System.Windows;

public class TransferViewModel : ViewModelBase
{
    IClientRep clientrep;

    public TransferViewModel(IClientRep clientrep)
    {
        this.clientrep = clientrep;
    }

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

    private string? idToSend;

    public string? IdToSend
    {
        get => idToSend;
        set
        {
            base.PropertyChangeMethod(out idToSend, value);
        }
    }

    

    private string? inputMoney;

    public string? InputMoney
    {
        get => inputMoney;
        set
        {
            base.PropertyChangeMethod(out inputMoney, value);
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

    private Command commandFindClient;
    public Command CommandFindClient => this.commandFindClient ??= new Command(
    execute: () => {
        try
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || Login.Length > 25 || Password.Length > 25)
                throw new Exception("credentials error");
            int id = this.clientrep.GetIdByLoginPassword(Login, Password);
            Client c = clientrep.GetById(id);
            bool isId = int.TryParse(IdToSend, out int Id2);
            Client c2 = clientrep.GetById(Id2);
            MessageBox.Show("users found");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    },
          canExecute: () => true);

    private Command commandToPay;
    public Command CommandToPay => this.commandToPay ??= new Command(
    execute: () => {
        try
        {

            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || Login.Length > 25 || Password.Length > 25 || !int.TryParse(IdToSend, out int id2))
                throw new Exception();

            if (!double.TryParse(InputMoney, out double money))
                throw new Exception();

            int id = this.clientrep.GetIdByLoginPassword(Login, Password);

            clientrep.TransferAccount(id, id2, money);

            Login = "";
            Password = "";
            IdToSend = "";
            InputMoney = "";
            MessageBox.Show("succesfully paid");
            App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<HomeViewModel>();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


    },
          canExecute: () => true);
}
