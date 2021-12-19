namespace Jobs.Domain.Entites
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
public    class Interview : BaseEntity
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        [Required(ErrorMessage = "Candidate required")]
        public Candidate Candidate { get; set; }
        [ForeignKey("Job")]
        public string JobId { get; set; }
        [Required(ErrorMessage = "Job required")]
        public Job Job { get; set; }

    }
}
