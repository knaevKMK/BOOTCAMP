namespace Jobs.Services.Commands.Job.Query
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

public    class JobBySkillQuery :IRequest<JobsListResult>
    {
        public string SkillName { get; set; }
    }


    public class JobBySkillQueryHandler : AppRequestHandler<JobBySkillQuery, JobsListResult>
    {
        public JobBySkillQueryHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<JobsListResult> Handle(JobBySkillQuery request, CancellationToken cancellationToken)
        {
            return new JobsListResult
            {
                Jobs = await _data.Jobs
                               .Where(j=>j.Skills.Where(s=>s.Name.Equals(request.SkillName)).Count()>0 && !j.IsDeleted )
                                .ProjectTo<JobViewModel>(_mapper)
                                .ToListAsync(cancellationToken)
            };
        }
    }
    public class JobsListResult {
        public List<JobViewModel> Jobs { get; set; }
    }
}
