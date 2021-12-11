
namespace Git.ViewModels.commit
{
using System;
using System.Collections.Generic;
using System.Text;
public    class CommitViewModel
    {
        public string Id { get; set; }
        public string RepositoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
