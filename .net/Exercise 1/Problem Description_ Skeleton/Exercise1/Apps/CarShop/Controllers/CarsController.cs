namespace CarShop.Controllers 
{
    using CarShop.Data.Models;
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IIssuesService issuesService;
        private readonly ICarsService carsService;
        public CarsController(IUsersService usersService, ICarsService carsService, IIssuesService issuesService)
        {
            this.usersService = usersService;
            this.carsService = carsService;
            this.issuesService = issuesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            string userId = this.GetUserId();
          
          ICollection<CarViewModel> cars =  carsService.getAll(userId)
                .Select(e=>new CarViewModel {
                    Id=e.Id,
                    Model=e.Model,
                    Year=e.Year,
                    ImageUrl=e.PictureUrl,
                    PlateNumber=e.PlateNumber,
                    RemainingUssues=issuesService.getAll(e.Id).Where(e=>!e.isFixed).Count(),
                    FixedUssues= issuesService.getAll(e.Id).Where(e=>e.isFixed).Count()
                })
                .ToList();
            return this.View(cars);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string userId = this.GetUserId();
            if (usersService.IsUserMechanic(userId)) {
                return this.Redirect("/Cars/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse AddPost(CarBindingModel carBinding)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
        
        string userId = this.GetUserId();
            if (usersService.IsUserMechanic(userId)) {
                return this.Error("You are Mechanic. You can not add cars");
            }
            
            Car car = new Car {
                Model = carBinding.Model,
                Year = carBinding.Year,
                PictureUrl = carBinding.Image,
                PlateNumber = carBinding.PlateNumber,
                OwnerId = userId,
            };
            try
            {
                carsService.Create(car);
            }
            catch (Exception e) {
                return this.Error(e.Message.ToString());
            }
            return this.Redirect("/Cars/All");

        }

    }
}
