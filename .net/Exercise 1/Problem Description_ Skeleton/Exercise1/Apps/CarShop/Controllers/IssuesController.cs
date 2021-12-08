
namespace CarShop.Controllers
{
    using CarShop.Data.Models;
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using CarShop.ViewModels.Issue;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
  public  class IssuesController:Controller
    {
        private readonly IIssuesService issuesService;
        private readonly ICarsService carsService;

        public IssuesController(ICarsService carsService, IIssuesService issuesService)
        {
            this.carsService = carsService;
            this.issuesService = issuesService;
        }

        public HttpResponse CarIssues(String carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            ICollection<IssueViewModel> issues = issuesService.getAll(carId).Select(e=>new IssueViewModel { 
            Id= e.Id,
            Description=e.Description,
            isFixed=e.isFixed,
            CarId=e.CarId
            }).ToList();
            Car car = carsService.getById(carId);
            return this.View(new CarViewModel {
                Id=carId, 
                Year=car.Year, 
                Model =car.Model, 
                Issues=issues,
            });
        }
        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View(carId);
        }
        [HttpPost]
        public HttpResponse Add(IssueBindingModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string id = issuesService.Create(new Issue { 
            Description=model.Description,
            isFixed=false,
            CarId=model.carId
            });
            return this.Redirect("/Issues/CarIssues?carId="+model.carId);
        }
        public HttpResponse Fix(String issueId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string carId = issuesService.Fix(issueId);
            if (carId==null)
            {
                return this.Error("Issue does not exist");
            }
            return this.Redirect("/Issues/CarIssues?carId=" + carId);
        }
        public HttpResponse Delete(string issueId,string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string _carId = issuesService.Delete(issueId);
            if (carId == null)
            {
                return this.Error("Issue does not exist");
            }
            return this.Redirect("/Issues/CarIssues?carId=" + _carId);
        }
    }
}
