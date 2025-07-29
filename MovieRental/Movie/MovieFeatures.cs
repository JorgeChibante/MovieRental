using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public async Task<Movie> Save(Movie movie)
		{
			_movieRentalDb.Movies.Add(movie);
			await _movieRentalDb.SaveChangesAsync();
			return movie;
		}

		// TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
		public async Task<List<Movie>> GetAll()
		{
			return await _movieRentalDb.Movies.ToListAsync();
		}


	}
}
