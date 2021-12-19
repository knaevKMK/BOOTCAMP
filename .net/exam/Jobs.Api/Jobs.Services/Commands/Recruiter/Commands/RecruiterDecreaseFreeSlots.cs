namespace Jobs.Services.Commands.Recruiter.Commands
{
    using AutoMapper;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class RecruiterDecreaseFreeSlots : IRequest<bool>
    {
        public string CandidateId { get; set; }
    }

    public class RecruiterDecreaseFreeSlotsHandler : AppRequestHandler<RecruiterDecreaseFreeSlots, bool>
    {
        public RecruiterDecreaseFreeSlotsHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<bool> Handle(RecruiterDecreaseFreeSlots request, CancellationToken cancellationToken)
        {
          var recruiter = _data.Candidates
                .Where(c => c.Id.Equals(request.CandidateId))
                .FirstOrDefault().Recruiter;
            if (recruiter == null)
            {
                return false;
            }
            if (recruiter.FreeSlots >=5)
            {
                return false;
            }
            recruiter.FreeSlots = recruiter.FreeSlots - 1;
            recruiter.Level = recruiter.Level + 1;
            await _data.SaveChangesAsync(CancellationToken.None);
            return (true);
        }
    }
}
