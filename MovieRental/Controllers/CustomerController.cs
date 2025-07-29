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
        public IActionResult Post([FromBody] Customer.Customer customer)
        {
            return Ok(_features.Save(customer));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_features.GetAll());
        }

    }
}