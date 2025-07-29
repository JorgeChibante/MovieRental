using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using MovieRental.Wpf.Models;

namespace MovieRental.Wpf.Services;

public class ApiService : IApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    const string baseUrl = "http://localhost:5219";
    
    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IEnumerable<Rental>?> GetCustomerRentals(string customerName)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var uriBuilder = new UriBuilder($"{baseUrl}/rental");
        var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        query["customerName"] = customerName;
        uriBuilder.Query = query.ToString();
        
        var response = await httpClient.GetAsync(uriBuilder.Uri);
        if (response.IsSuccessStatusCode)
        {
            IEnumerable<Rental>? rentals = await response.Content.ReadFromJsonAsync<IEnumerable<Rental>>();
            return rentals;
        }

        return null;
    }
}