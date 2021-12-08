namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Users;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

 
    public class UsersController : Controller
    {

        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginBindingModel model)
        {

            string id = "";
            try
            {
              id=usersService.GetUserId(model.Username, model.Password);
            }
            catch (Exception e) {
                return this.Error(e.Message);
            }
            this.SignIn(id);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterBindingModel model)
        {
            //  if (!ModelState.isValid) { }
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return Redirect("/Users/Register");
            }
            try
            {
                usersService.Create(model.Username, model.Email, model.Password, model.UserType);
            }
            catch (Exception e) {
                return this.Error(e.Message);
            }
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout() {
            this.SignOut();
            return Redirect("/");
        }
    }
}
