﻿namespace MoviesCatalogAPI.Models
{
    public class MovieRating
    {
        public int MovieRatingId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
