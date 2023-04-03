using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Interface
{
    public interface IMovieRating
    {
        public void RateMovie(MovieRating movieRating);
        public MovieRating RemoveRate(MovieRating movieRating);
        public IEnumerable<MovieRating> GetRating();
        public MovieRating GetRatingByUserandMovie(MovieRating movieRating);

    }
}
