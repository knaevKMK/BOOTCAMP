namespace Jobs.Services.Commands.Candidate.Query
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
public    class CandidateByIdQuery : IRequest<CandidateByIdQueryResult>
    {
        public string Id { get; set; } 
    }
    public class CandidateByIdQueryHandler : AppRequestHandler<CandidateByIdQuery, CandidateByIdQueryResult>
    {
        public CandidateByIdQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<CandidateByIdQueryResult> Handle(CandidateByIdQuery request, CancellationToken cancellationToken)
        {
            // Candidate candidate = await _data.Candidates.FindAsync( request.Id);
            return new CandidateByIdQueryResult
            {
                Candidate = await _data.Candidates
                                .Where(c => c.Id.ToString().Equals(request.Id))
                                .ProjectTo<CandidateDetailsViewModel>(_mapper)
                                .FirstOrDefaultAsync(cancellationToken)
            };
        }
    }
    public class CandidateByIdQueryResult
    {
        public CandidateDetailsViewModel Candidate { get; set; }
    }
}
