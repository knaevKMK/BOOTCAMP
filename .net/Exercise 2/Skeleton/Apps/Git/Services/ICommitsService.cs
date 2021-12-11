using Git.ViewModels.commit;
using System.Collections.Generic;

namespace Git.Services
{
public interface ICommitsService
    {
        void Create(string description, string userId, string repoId);
        ICollection<CommitViewModel> GetAll(string repoId);
        void Delete(string id, string userId);
    }
}
