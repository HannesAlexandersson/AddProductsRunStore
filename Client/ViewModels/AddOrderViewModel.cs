using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddOrderViewModel : ViewModelBase
{

    [RelayCommand]
    private async Task AddOrder()
    {
        System.Console.WriteLine("Hej du tryckte på mig ");
    }
}
