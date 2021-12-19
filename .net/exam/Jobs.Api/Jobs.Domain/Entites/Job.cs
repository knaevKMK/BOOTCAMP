namespace Jobs.Domain.Entites
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Job : BaseEntity
    {

        [Required(ErrorMessage = "Job Title required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Job Description required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Job Salary required")]
        [Range(0.00,100000.00,ErrorMessage ="Salary must be positive in range under 100000")]
        public decimal Salary { get; set; }
        public virtual ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
    }
}
