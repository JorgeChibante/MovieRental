using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeature
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public CustomerFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }
    
        public async Task<Customer> Save(Customer customer)
        {
            _movieRentalDb.Customers.Add(customer);
            await _movieRentalDb.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _movieRentalDb.Customers.ToListAsync();
        }
    }
}