using MoviesCatalogAPI.Data;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Repository
{
    public class MovieRatingRepository : IMovieRating
    {
        readonly MovieDbContext _dbContext;
        public MovieRatingRepository(MovieDbContext dbContext) 
        {
            _dbContext=dbContext;
        }
        public IEnumerable<MovieRating> GetRating()
        {
            return _dbContext.movieRatings.ToList();
        }

        public MovieRating? GetRatingByUserandMovie(MovieRating movieRating)
        {
            var rating= _dbContext.movieRatings.Where(x=> x.UserId == movieRating.UserId && x.MovieId== movieRating.MovieId).FirstOrDefault();
            return rating ?? null;
        }

        public void RateMovie(MovieRating movieRating)
        {
             _dbContext.movieRatings.Add(movieRating);
            _dbContext.SaveChanges();
        }

   
        public MovieRating RemoveRate(MovieRating movieRating)
        {
            MovieRating? movieRate = _dbContext.movieRatings.Where(x=> x.MovieId== movieRating.MovieId && x.UserId== movieRating.UserId).FirstOrDefault();
            if (movieRate != null)
            {
                _dbContext.movieRatings.Remove(movieRate);
                _dbContext.SaveChanges();
                return movieRate;
            }
            else throw new ArgumentNullException();

           
        }
    }
}
