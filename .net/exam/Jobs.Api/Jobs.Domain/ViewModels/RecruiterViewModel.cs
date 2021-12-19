
namespace Jobs.Domain.ViewModels
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 public   class RecruiterViewModel
    {

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public List<CandidateDetailsViewModel> Candidates { get; set; }
    }
}
