using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
 public   interface ICarsService
    {
        void Create(Car car);
        Car getById(string id);
        ICollection<Car> getAll(string userId);
    }
}
