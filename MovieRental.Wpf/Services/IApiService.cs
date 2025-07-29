using MovieRental.Wpf.Models;

namespace MovieRental.Wpf.Services;

public interface IApiService
{
    Task<IEnumerable<Rental>?> GetCustomerRentals(string customerName);
}