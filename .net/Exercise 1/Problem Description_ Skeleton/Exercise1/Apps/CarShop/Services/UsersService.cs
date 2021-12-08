using CarShop.Data;
using CarShop.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService: IUsersService
    {
        private readonly ApplicationDbContext data;

        public UsersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                isMechanic=userType.ToLower().Equals("mechanic")
            };
            data.Users.Add(user);
            data.SaveChangesAsync();
        }

        public User getById(string id)
        {
            return data.Users.FirstOrDefault(e => e.Id.Equals(id));
        }

        public string GetUserId(string username, string password)
        {
         return   data.Users.FirstOrDefault(e => e.Username.Equals(username) && e.Password.Equals(password)).Id;
        }

        public bool IsUserMechanic(string Userid)
        {
            User user = this.getById(Userid);
            if (user == null) {
                return false;
            }
            return user.isMechanic;
        }

        public bool IsUsernameAvailable(string username)
        {
            User user = data.Users.FirstOrDefault(e => e.Username.Equals(username));
            return user != null;
        }
    }
}
