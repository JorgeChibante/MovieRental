namespace MovieRental.Customer;

public interface ICustomerFeature
{
    Task<Customer> Save(Customer customer);
    
    Task<IEnumerable<Customer>> GetAll();
}