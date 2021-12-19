namespace Jobs.Services.Commands.Skill.Query
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
public    class SkillByIdQuery : IRequest<SkillByIdQueryResult>
    {
        public string Id { get; set; }
    }

    public class CandidateByIdQueryHandler : AppRequestHandler<SkillByIdQuery, SkillByIdQueryResult>
    {
        public CandidateByIdQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<SkillByIdQueryResult> Handle(SkillByIdQuery request, CancellationToken cancellationToken)
        {
            return new SkillByIdQueryResult
            {
                Skill = await _data.Skills
                                .Where(c => c.Id.Equals(request.Id))
                                .ProjectTo<SkillViewModel>(_mapper)
                                .FirstOrDefaultAsync(cancellationToken)
            };
        }
    }
    public class SkillByIdQueryResult
    {
        public SkillViewModel Skill { get; set; }
    }
}
