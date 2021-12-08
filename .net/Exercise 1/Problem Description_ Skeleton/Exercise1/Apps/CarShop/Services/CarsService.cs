using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext data;
        private readonly IUsersService usersService;
        public CarsService(ApplicationDbContext data, IUsersService usersService)
        {
            this.data = data;
            this.usersService = usersService;
        }

        public void Create(Car car)
        {
            data.Cars.Add(car);
            data.SaveChanges();
        }

        public ICollection<Car> getAll(string userId)
        {
       
            if (usersService.IsUserMechanic(userId))
            {
                List<Car> cars = data.Cars.Where(e => e.Issues.FirstOrDefault(s => !s.isFixed) != null)
                .ToList();
                return cars;
            }

            return data.Cars
                .Where(e => e.OwnerId == userId)
                .ToList();
        }

        public Car getById(string id)
        {
            return data.Cars.FirstOrDefault(e => e.Id == id);
        }
    }
}
