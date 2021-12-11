
namespace Git.Services
{
    using Git.Data;
    using Git.Data.Entities;
    using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext data;

        public UsersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string CreateUser(string username, string email, string password)
        {
            User user = new User { 
            Username=username,
            Email=email,
            Password=password
            };
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User> entityEntry = data.Users.Add(user);
            data.SaveChanges();
            return entityEntry.Entity.Username;
        }

        public string GetUserId(string username, string password)
        {
            User user = data.Users
                .FirstOrDefault(e => e.Username == username && e.Password==password);
            return user != null ? user.Id : null;
        }

        public bool IsEmailAvailable(string email)
        {
            return data.Users.FirstOrDefault(e => e.Email.Equals(email)) != null;
        }

        public bool IsUsernameAvailable(string username)
        {
            return data.Users.FirstOrDefault(e => e.Username.Equals(username)) != null;
        }
    }
}
