using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MoviesCatalogAPI.Data;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieRatingController : ControllerBase
    {
        private readonly IMovieRating _IMovieRating;
        public MovieRatingController(IMovieRating movie) 
        {
            _IMovieRating = movie;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<MovieRating>>> Get() 
        { 
            var movieRatings =  _IMovieRating.GetRating();
            return Task.FromResult<ActionResult<IEnumerable<MovieRating>>>(Ok(movieRatings));
        }

        [HttpPost]
        public Task<ActionResult<MovieRating>> Rate(MovieRating movieRating)
        {
            try
            {
                if (_IMovieRating.GetRatingByUserandMovie(movieRating) is null)
                {
                    _IMovieRating.RateMovie(movieRating);
                    return Task.FromResult<ActionResult<MovieRating>>(Ok(movieRating));
                }else
                    return Task.FromResult<ActionResult<MovieRating>>(BadRequest("The Movie was already rated by this user"));

            }
            catch (Exception ex)
            {
               return Task.FromResult<ActionResult<MovieRating>>(BadRequest("There was an error Rating the Movie"));
            }
        }

        [HttpDelete]
        public ActionResult DeleteRate(MovieRating movieRating) 
        {
            try {
                if (_IMovieRating.GetRatingByUserandMovie(movieRating) is null)
                {
                    return NotFound("Rating was not Found");
                }
                else
                {
                    _IMovieRating.RemoveRate(movieRating);
                    return Ok("Rating deleted successfully");
                }
            } catch(Exception e) { 
            return BadRequest("There was an error Deleting the Rate");
            }
            
           
        }
    }
}
