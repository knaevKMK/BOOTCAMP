
namespace Git.Services
{
    using Git.Data;
    using Git.Data.Entities;
    using Git.ViewModels.commit;
    using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
public    class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext data;
        private readonly IUsersService usersService;

        public CommitsService(ApplicationDbContext data, IUsersService usersService)
        {
            this.data = data;
            this.usersService = usersService;
        }

        public void Create(string description, string userId, string repoId)
        {
           
            var commit = new Commit
            {
                Description = description,
                CreateOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repoId
            };
            data.Commits.Add(commit);
            data.SaveChanges();
        }

        public void Delete(string id, string userId)
        {
            Commit commit = data.Commits.FirstOrDefault(e => e.Id == id);
            if (commit == null)
            {
                throw new NullReferenceException("Commit does not exist");
            }
            if (commit.CreatorId != userId)
            {
                throw new ArgumentException("You are not authorize to delete this commit");
            }
            data.Commits.Remove(commit);
            data.SaveChanges();
        }

        public ICollection<CommitViewModel> GetAll(string userId)
        {
            return data.Commits
                 .Where(c => c.CreatorId == userId)
                 .Select(c => new CommitViewModel {
                         Description= c.Description,
                         Id=c.Id,
                         RepositoryName= c.Repository.Name,
                         CreateOn=c.CreateOn
                 })
                 .ToList();
        }
    }
}
