namespace Jobs.Services.Common.Infrastructure
{
    using Jobs.Domain.Entites;
    using Jobs.Services.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public  class ApplicationDbContext :DbContext, IApplicaitonDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
