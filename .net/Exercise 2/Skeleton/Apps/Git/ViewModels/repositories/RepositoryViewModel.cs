
namespace Git.ViewModels.repositories
{
using System;
using System.Collections.Generic;
using System.Text;
    public  class RepositoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public DateTime CreateOn { get; set; }
        public int CommitsCount { get; set; }

    }
}
