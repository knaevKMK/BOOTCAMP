﻿

namespace CarShop
{
    using CarShop.Data;
    using CarShop.Services;

    using Microsoft.EntityFrameworkCore;

    using SUS.HTTP;
    using SUS.MvcFramework;

    using System.Collections.Generic;
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
             //   db.Database.Migrate();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
           
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}