using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial.Buffers;

namespace MoviesCatalogAPI.Controllers
{
    [Authorize]
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovies _IMovie;

        public MovieController(IMovies Imovie)
        {
            _IMovie = Imovie;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get([FromQuery] MovieParameters movieParameters)
        {
            var movies = _IMovie.GetMovieDetails(movieParameters);
            var metadata = new
            {
                movies.TotalCount,
                movies.PageSize,
                movies.CurrentPage,
                movies.TotalPages,
                movies.HasNext,
                movies.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(movies);// await Task.FromResult(_IMovie.GetMovieDetails(movieParameters));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await Task.FromResult(_IMovie.GetMovieDetails(id));
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Post(Movie movie)
        {
            _IMovie.AddMovie(movie);
            return await Task.FromResult(movie);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> Put(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }
            try
            {
                _IMovie.UpdateMovie(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(movie);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            var movie = _IMovie.DeleteMovie(id);
            return await Task.FromResult(movie);
        }


        private bool MovieExists(int id)
        {
            return _IMovie.CheckMovie(id);
        }



    }
}
