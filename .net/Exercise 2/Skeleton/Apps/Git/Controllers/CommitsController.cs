
namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.commit;
    using Git.ViewModels.repositories;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System;
using System.Collections.Generic;
using System.Text;
public    class CommitsController :Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(IRepositoriesService repositoriesService, ICommitsService commitsService)
        {
            this.repositoriesService = repositoriesService;
            this.commitsService = commitsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            ICollection<CommitViewModel> all = this.commitsService.GetAll(this.GetUserId());
            return this.View(all);
        }
        public HttpResponse Create(String id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

         var repo= repositoriesService.findById(id);
            return this.View(new RepositoryViewModel{ Name= repo.Name, Id=repo.Id });

        }
        [HttpPost]
        public HttpResponse CreateConfirm(CommitBindingModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            try
            {
                commitsService.Create(model.description, this.GetUserId(), model.id);
                return Redirect("/Repositories/All");
            }
            catch (Exception e)
            {

                return this.Error(e.Message);
            }
            
        }
        public HttpResponse Delete(String id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            try
            {
                commitsService.Delete(id, this.GetUserId());
            return this.Redirect("/Commits/All");
            }
            catch (Exception e) {
                return this.Error(e.Message);
            }
        }
    }
}
