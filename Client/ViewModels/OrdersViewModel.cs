using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{

    [ObservableProperty]
    public partial ObservableCollection<Order> Orders { get; set; } = [];

    public OrdersViewModel()
    {
        PageTitle = "Beställningar";
        Init();

    }

    private async void Init()
    {
        await LoadOrders();
    }

    private async Task LoadOrders()
    {
        try
        {
            // Orders = new ObservableCollection<Order>(await _service.List());
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
