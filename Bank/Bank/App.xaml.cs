
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bank;

using Bank.ViewModels;
using Bank.Repositories.EF_Core_Repositories;
using Bank.Repositories.Dapper_Repositories;
using Bank.ViewModels.Base;
using SimpleInjector;
using Bank.Repositories.Base;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static Container Container { get; set; } = new Container();

    protected override void OnStartup(StartupEventArgs e)
    {
        this.RegisterContainer();

        this.Start<HomeViewModel>();

        base.OnStartup(e);
    }

    private void Start<T>() where T : ViewModelBase
    {
        var mainView = new MainWindow();
        var mainViewModel = Container.GetInstance<MainViewModel>();
        mainViewModel.ActiveViewModel = Container.GetInstance<T>();

        mainView.DataContext = mainViewModel;

        mainView.ShowDialog();
    }

    private void RegisterContainer()
    {
        Container.RegisterSingleton<IClientRep, ClientEFCoreRep>();
        Container.RegisterSingleton<ILoanClientRep, LoanClientEFCoreRep>();
        Container.RegisterSingleton<IDebtorClientRep, DebtorClientEFCoreRep>();

        Container.RegisterSingleton<HomeViewModel>();
        Container.RegisterSingleton<MainViewModel>();
        
        


        Container.Verify();
    }
}
