using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    private readonly IOrderService _orderService;

    [ObservableProperty]
    public partial ObservableCollection<Order> Orders { get; set; } = [];

    public OrdersViewModel(IOrderService ordersService)
    {
        _orderService = ordersService;
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
            Orders = new ObservableCollection<Order>(await _orderService.List());
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
