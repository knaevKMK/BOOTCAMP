using System;
using System.Collections.Generic;

namespace Jobs.Domain.ViewModels
{
public  class CandidateDetailsViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        //public List<string> Skills { get; set; }
        public string Recruiter { get; set; }
    }
}
