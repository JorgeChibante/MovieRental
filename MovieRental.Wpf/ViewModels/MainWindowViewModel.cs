using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MovieRental.Wpf.Models;
using MovieRental.Wpf.Services;

namespace MovieRental.Wpf.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly IApiService _apiService;
    

    public MainWindowViewModel(IApiService  apiService)
    {
        _apiService = apiService;
        GetRentalsCommand = new AsyncRelayCommand(GetRentals);
    }
    
    public ICommand GetRentalsCommand { get; }
    
    public string CustomerName { get; set; }

    private IEnumerable<Rental> _rentals;
    public IEnumerable<Rental> Rentals
    {
        get => _rentals;
        set => SetField(ref _rentals, value);
    }

    private async Task GetRentals()
    {
        var rentals =  await _apiService.GetCustomerRentals(CustomerName);
        Rentals = rentals;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}