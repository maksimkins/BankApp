using Bank.ViewModels.Base;
using System;
using System.Collections.Generic;
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


}
