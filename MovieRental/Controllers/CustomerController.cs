using Microsoft.AspNetCore.Mvc;
using MovieRental.Customer;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFeature _features;

        public CustomerController(ICustomerFeature features)
        {
            _features = features;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer.Customer customer)
        {
            return Ok(await _features.Save(customer));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _features.GetAll());
        }

    }
}