namespace Jobs.Domain.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

public    class Candidate: BaseEntity
    {
        [Required(ErrorMessage = "Candidate First Name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Candidate Last Name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Candidate Email required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Candidate Bio required")]
        public string Bio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Skill> Skills { get; set; } 
        [ForeignKey("Recruiter")]
        public string RecruiterId { get; set; }
        [Required(ErrorMessage = "Recruiter required")]
        public Recruiter Recruiter { get; set; }
        public Candidate()
        {
            this.Skills = new HashSet<Skill>(); 
        }
    }
}
