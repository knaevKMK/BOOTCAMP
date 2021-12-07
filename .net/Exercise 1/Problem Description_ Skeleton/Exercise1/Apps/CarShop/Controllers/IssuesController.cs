
namespace CarShop.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;
  public  class IssuesController:Controller
    {
        //[HttpGet("/issues/carissues")]
        public HttpResponse All()
        {
            return this.View();
        }
        //[HttpGet("/issues/add")]
        public HttpResponse Add()
        {
            return this.View();
        }

    }
}
