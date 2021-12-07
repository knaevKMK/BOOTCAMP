namespace CarShop.Controllers 
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CarsController : Controller
    {
        //[HttpGet("/cars/all")]
        public HttpResponse All()
        {
            return this.View();
        }

        //[HttpGet("/cars/add")]
        public HttpResponse Add()
        {
            return this.View();
        }
    }
}
