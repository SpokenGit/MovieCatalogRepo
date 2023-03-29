using Microsoft.EntityFrameworkCore;
using MoviesCatalogAPI.Data;
using MoviesCatalogAPI.Interface;
using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Repository
{
    public class UserRepository : IUsers
    {
        readonly MovieDbContext _dbContext;

        public UserRepository(MovieDbContext dbContext) {
            _dbContext= dbContext;
        }

        public User GetUser(string usuario, string pass)
        {
            try
            {
                User? user =  _dbContext.Users.FirstOrDefault(x=> x.UserName == usuario && x.UserPassword==pass);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return user;
                }
            }
            catch
            {
                throw new ArgumentNullException(); ;
            }
        }
    }
}
