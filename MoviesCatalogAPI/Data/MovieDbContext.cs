

using Microsoft.EntityFrameworkCore;
using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Data
{
    public class MovieDbContext :DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {       }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<MovieRating> movieRatings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CNN");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
