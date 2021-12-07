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
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginBindingModel model)
        {
            string id = usersService.GetUserId(model.Username, model.Password);
            this.SignIn(id);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
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

            usersService.Create(model.Username, model.Email, model.Password, model.UserType);
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout() {
            this.SignOut();
            return Redirect("/");
        }
    }
}
