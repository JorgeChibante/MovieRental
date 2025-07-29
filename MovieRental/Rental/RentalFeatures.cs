using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.PaymentProviders;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		private readonly PaymentProviderFactory _paymentProviderFactory;

		public RentalFeatures(MovieRentalDbContext movieRentalDb, PaymentProviderFactory paymentProviderFactory)
		{
			_movieRentalDb = movieRentalDb;
			_paymentProviderFactory = paymentProviderFactory;
		}

		//TODO: make me async :(
		public async Task<Rental> Save(Rental rental)
		{
			//Get movie before saving to get the cost per day
			var movie = await _movieRentalDb.Movies.FindAsync(rental.MovieId);
			if (movie == null)
			{
				throw new ArgumentNullException(nameof(rental.MovieId));
			}
			
			//payment provider should never be null because it throws an exception
			var paymentProvider = _paymentProviderFactory.GetPaymentProvider(rental.PaymentMethod)!;
			await paymentProvider.Pay(rental.DaysRented * movie.PricePerDay);
			
			_movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it
		public async Task<IEnumerable<Rental>> GetRentalsByCustomerName(string customerName)
		{
			return await _movieRentalDb.Rentals
				.Where(x => x.Customer.CustomerName == customerName).ToListAsync();
		}

	}
}
