
namespace Git.Services
{
    using Git.Data.Entities;
    using Git.ViewModels.repositories;
    using System;
using System.Collections.Generic;
using System.Text;
public    interface IRepositoriesService
    {
        void Create(string name, bool isPublic, string userId);
        ICollection<RepositoryViewModel> getAll();
        Repository findById(string id);
    }
}
