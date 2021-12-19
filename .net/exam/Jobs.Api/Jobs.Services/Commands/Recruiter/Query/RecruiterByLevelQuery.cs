namespace Jobs.Services.Commands.Recruiter.Query
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Jobs.Domain.ViewModels;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
 public   class RecruiterByLevelQuery : IRequest<RecruiterAllQueryResult>
    {
        public int? Level { get; set; }
    }

public class RecruiterByLevelQueryHandler : AppRequestHandler<RecruiterByLevelQuery, RecruiterAllQueryResult>
{
    public RecruiterByLevelQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
    {
    }

    public override async Task<RecruiterAllQueryResult> Handle(RecruiterByLevelQuery request, CancellationToken cancellationToken)
    {
        return new RecruiterAllQueryResult
        {
            Recruiters = await _data.Recruiters
                            .Where(c => c.Level ==request.Level && !c.IsDeleted)
                            .ProjectTo<RecruiterViewModel>(_mapper)
                            .ToListAsync(cancellationToken)
        };
    }
}
public class RecruiterAllQueryResult
    {
    public List<RecruiterViewModel> Recruiters { get; set; }
}

}
