namespace Jobs.Domain.Entites
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  public  class Recruiter : BaseEntity
    {
        [Required(ErrorMessage = "Recruiter Last Name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Recruiter Email required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public int Level { get; set; } = 1;
        public int FreeSlots { get; set; } = 5;

    }
}
