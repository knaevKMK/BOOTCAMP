namespace Jobs.Services.Commands.Skill.Query
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
public    class SkillActiveQuery : IRequest<SkillActiveQueryResult>
    {
    }

    public class SkillActiveQueryHandler : AppRequestHandler<SkillActiveQuery, SkillActiveQueryResult>
    {
        public SkillActiveQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<SkillActiveQueryResult> Handle(SkillActiveQuery request, CancellationToken cancellationToken)
        {
            return new SkillActiveQueryResult
            {
                Skills = await _data.Skills
                                .Where(c => c.IsDeleted==false)
                                .ProjectTo<SkillViewModel>(_mapper)
                                .ToListAsync(cancellationToken)
            };
        }
    }
    public class SkillActiveQueryResult
    {
        public List<SkillViewModel> Skills { get; set; }
    }
}
