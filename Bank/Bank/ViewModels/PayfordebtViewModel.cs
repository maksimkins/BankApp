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

public class PayfordebtViewModel : ViewModelBase
{
    private IDebtorClientRep debrep;
    public PayfordebtViewModel(IDebtorClientRep debrep)
    {
        this.debrep = debrep;
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

    private string? amoountOfMoney;

    public string? AmoountOfMoney
    {
        get => amoountOfMoney;
        set
        {
            base.PropertyChangeMethod(out amoountOfMoney, value);
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
                throw new Exception();
            int id = this.debrep.GetIdByLoginPassword(Login, Password);
            DebtorClient l = debrep.GetById(id);
            AmoountOfMoney = l.DebtToReturn.ToString();
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

            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || Login.Length > 25 || Password.Length > 25)
                throw new Exception();

            if (!double.TryParse(InputMoney, out double money))
                throw new Exception();

            int id = this.debrep.GetIdByLoginPassword(Login, Password);
            this.debrep.PayForDebt(id, money);
            Login = "";
            Password = "";
            AmoountOfMoney = "";
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
