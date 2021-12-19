namespace Jobs.Domain.Entites
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public class Skill : BaseEntity
    {
        [Required(ErrorMessage = "Name required")]
        [StringLength(20, ErrorMessage = "First Name max length 20 chars")]
        public string Name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
