﻿using Microsoft.EntityFrameworkCore;
using MoviesCatalogAPI.Data;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;
using System.Linq;

namespace MoviesCatalogAPI.Repository
{
    public class MovieRepository :IMovies
    {
        readonly MovieDbContext _dbContext ;

        public MovieRepository(MovieDbContext dbContext) {
            _dbContext = dbContext ;
        }

        public void AddMovie(Movie movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckMovie(int id)
        {
            return _dbContext.Movies.Any(e => e.MovieId == id);
        }

        public Movie DeleteMovie(int id)
        {
            try
            {
                Movie? movie = _dbContext.Movies.Find(id);

                if (movie != null)
                {
                    _dbContext.Movies.Remove(movie);
                    _dbContext.SaveChanges();
                    return movie;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public PagedList<Movie> GetMovieDetails(MovieParameters movieParameters)
        {
            try
            {
              
                IQueryable<Movie> movies = _dbContext.Movies ; 

                FilterByText(ref movies, movieParameters);
                SearchByText(ref movies, movieParameters.Searchby);

                 
                return PagedList<Movie>.ToPagedList(movies, movieParameters.PageNumber,movieParameters.PageSize);
               
            }
            catch
            {
                throw;
            }
        }

        public Movie GetMovieDetails(int id)
        {
            try
            {
                Movie? movie = _dbContext.Movies.Find(id);
                if (movie != null)
                {
                    return movie;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateMovie(Movie movie)
        {
            try
            {
                _dbContext.Entry(movie).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private void SearchByText(ref IQueryable<Movie> movies, string searchText)
        {
            if (!movies.Any() || string.IsNullOrWhiteSpace(searchText))
                return;
            movies = movies.Where(o => o.MovieName.ToLower().Contains(searchText.Trim().ToLower()) || o.MovieSynopsis.ToLower().Contains(searchText.Trim().ToLower()));
        }

        private void FilterByText(ref IQueryable<Movie> movies, MovieParameters movieParameters)
        {
            if (!string.IsNullOrEmpty(movieParameters.Yearrelease))
                movies = movies.Where(x=> x.MovieReleaseyear.Equals(movieParameters.Yearrelease.Trim()));

            if (!string.IsNullOrEmpty(movieParameters.Category))
                movies = movies.Where(x => x.MovieCategory.Equals(movieParameters.Category.Trim()));

        }

    }
}
