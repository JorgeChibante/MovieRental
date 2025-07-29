using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }

        [HttpGet()]
        public async Task<IActionResult> GetByCustomerName([FromQuery] string customerName)
        {
            return Ok(await _features.GetRentalsByCustomerName(customerName));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rental.Rental rental)
        {
	        return Ok(await _features.Save(rental));
        }

	}
}
