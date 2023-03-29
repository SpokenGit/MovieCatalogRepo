using MoviesCatalogAPI.Models;

namespace MoviesCatalogAPI.Interface
{
    public interface IUsers
    {
        public User GetUser(string user,string pass);
        public void AddUser(User user);
    }
}
