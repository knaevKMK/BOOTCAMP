
namespace Jobs.Services.Common.Interfaces
{
using Jobs.Domain.Entites;
using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public    interface IApplicaitonDbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
