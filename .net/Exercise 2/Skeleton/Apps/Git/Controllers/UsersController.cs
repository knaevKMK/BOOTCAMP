namespace Git.Controllers
{
using Git.Services;
using Git.ViewModels.user;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
   public class UsersController:Controller
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
                return this.Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse LoginConfirm(LoginBindingModel model)
        {
            string id = usersService.GetUserId(model.Username, model.Password);
            if (id==null)
            {
                return this.Error("Invalid login data");
            }
            this.SignIn(id);
            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse RegisterConfirm(RegisterBindingModel model)
        {
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                return this.Error("Passwords not matched");
//                return Redirect("/Users/Register");
            }
            if (usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username Allreadey reserved");
                //                return Redirect("/Users/Register");
            }
            if (usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email Allreadey reserved");
                //                return Redirect("/Users/Register");
            }
            try
            {
                string username = usersService.CreateUser(model.Username, model.Email, model.Password);
                if (username==null)
                {
                    throw new Exception("Somethig went worng");
                }
            }
            catch (Exception e)
            {
                return this.Error(e.Message);
            }
            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
