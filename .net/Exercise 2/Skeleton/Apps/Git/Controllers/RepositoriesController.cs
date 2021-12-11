
namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.repositories;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
using System.Collections.Generic;
using System.Text;
public    class RepositoriesController: Controller
    {
        private readonly IRepositoriesService repositoriesService;
       

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
           
            ICollection<RepositoryViewModel> all = repositoriesService.getAll();
            return this.View(all);
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
        [HttpPost]
        public HttpResponse CreateConfirm(RepositoryBindingModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            try
            {
                repositoriesService.Create(model.Name, model.RepositoryType.ToLower() == "public", this.GetUserId());
            }
            catch (Exception e) {
                return this.Error(e.Message);
            }
            return this.Redirect("/Repositories/All");
        }
    }
}
