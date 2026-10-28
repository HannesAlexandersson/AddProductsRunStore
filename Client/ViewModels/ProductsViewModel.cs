using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private readonly IProductService _productService;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = [];

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    public string DeleteId { get; set; }

    public ProductsViewModel()
    {
        _productService = new ProductServices();
        PageTitle = "Våra produkter";
        DeleteId = "";
        Init();
    }

    public ProductsViewModel(IProductService productService)
    {
        _productService = productService;
        PageTitle = "Våra produkter";
        DeleteId = "";

        // Task.Run(()=> LoadProducts()).Wait();
        Init();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            ShowDialog = true;
            DeleteId = id;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private async void Init()
    {
        await LoadProducts();
    }

    [RelayCommand]
    private async Task Confirm()
    {
        Console.WriteLine("Tar bort produkten");
        ShowDialog = false;

        ProductRestDb product = await _productService.Find(DeleteId);
        if (product is not null)
        {
            await _productService.Delete(product._id);
            await LoadProducts();
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        Console.WriteLine("Jasååå, du ångrar dig fegis!");
        ShowDialog = false;
    }

    private async Task LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(await _productService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
