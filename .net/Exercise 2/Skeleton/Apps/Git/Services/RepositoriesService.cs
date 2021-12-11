
using Git.Data;
using Git.Data.Entities;
using Git.ViewModels.repositories;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext data;

        public RepositoriesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string name, bool isPublic, string userId)
        {
            Repository repository = new Repository {
                Name = name,
                IsPublic = isPublic,
                OwnerId = userId,
                CreateOn = System.DateTime.Now,
            };

            data.Repositories.Add(repository);
            data.SaveChanges();
        }

        public Repository findById(string id)
        {
            return data.Repositories.FirstOrDefault(e => e.Id == id);
        }

        public ICollection<RepositoryViewModel> getAll()
        {
        return    data.Repositories
                .Where(e=>e.IsPublic)
                 .Select(e => new RepositoryViewModel
                 {
                     Id=e.Id,
                     Name=e.Name,
                     OwnerName=e.Owner.Username,
                     CreateOn=e.CreateOn,
                     CommitsCount=e.Commits.Count()
                 })
                 .ToList();
        }
    }
}
