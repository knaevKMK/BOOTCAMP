namespace Jobs.Services.Commands.Interview
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
public    class InterviewGetAllQuery : IRequest<InterviewListResult>
    {
    }

    public class SkillActiveQueryHandler : AppRequestHandler<InterviewGetAllQuery, InterviewListResult>
    {
        public SkillActiveQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<InterviewListResult> Handle(InterviewGetAllQuery request, CancellationToken cancellationToken)
        {
            return new InterviewListResult
            {
                Interviews = await _data.Interviews
                                .Where(c => !c.IsDeleted)
                                .ProjectTo<InterviewViewModel>(_mapper)
                                .ToListAsync(cancellationToken)
            };
        }
    }
    public class InterviewListResult
    {
        public List<InterviewViewModel> Interviews { get; set; }
    }
}
