using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Interface
{
    public interface IMovies
    {
        public PagedList<Movie> GetMovieDetails(MovieParameters movieParameters);
        public Movie GetMovieDetails(int id);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
        public Movie DeleteMovie(int id);
        public bool CheckMovie(int id);
    }
}
