
namespace Jobs.Services.Commands.Recruiter.Query
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Jobs.Domain.ViewModels;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
public    class RecruiterGetAllWithCandidatesQuery : IRequest<RecruiterAllQueryResult>
    {
    }
    public class RecruiterGetAllWithCandidatesQueryHandler : AppRequestHandler<RecruiterGetAllWithCandidatesQuery, RecruiterAllQueryResult>
    {
        public RecruiterGetAllWithCandidatesQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<RecruiterAllQueryResult> Handle(RecruiterGetAllWithCandidatesQuery request, CancellationToken cancellationToken)
        {
            return new RecruiterAllQueryResult
            {
                Recruiters = await _data.Recruiters
                                .Where(c => c.Candidates.Count> 0 && !c.IsDeleted)
                                .ProjectTo<RecruiterViewModel>(_mapper)
                                .ToListAsync(cancellationToken)
            };
        }
    }
   
}
