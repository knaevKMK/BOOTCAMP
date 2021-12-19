namespace Jobs.Services.Commands.Job.Commnads
{
    using Jobs.Domain.Entites;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Jobs.Services.Commands.Skill.Commands;
    using System.Linq;

    public  class AddJobCommand : IRequest<string>
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public List<SkillCreateCommand> Skills { get; set; }
    }
    public class AddJobCommandHandler : AppRequestHandler<AddJobCommand, string>
    {
        public AddJobCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
   
        }

        public override async Task<string> Handle(AddJobCommand request, CancellationToken cancellationToken)
        {


            Job job = new Job {
                Title = request.Title,
                Description = request.Description,
            Salary=request.Salary
            };


            // create skills 
            foreach (var skill in request.Skills)
                {
                job.Skills.Add(new Skill { Name = skill.Name });
                }

            _data.Jobs.Add(job);
            await _data.SaveChangesAsync(CancellationToken.None);

            //create interview

            var candidatesId = new HashSet<string>();
            foreach (var skill in job.Skills)
            {
                candidatesId.Concat(_data.Candidates
                    .Where(c => c.Skills.Contains(skill) && c.Recruiter.FreeSlots > 0)
                    .Select(c => c.Id)
                    .ToHashSet());
            }


            foreach (var candidateId in candidatesId)
            {
              
                    Interview interview = new Interview
                    {
                        JobId = job.Id,
                        CandidateId = candidateId
                    };
                    _data.Interviews.Add(interview);

                var recruiter = _data.Candidates
                     .Where(c => c.Id.Equals(candidateId))
                     .FirstOrDefault().Recruiter;
                        
                        if (recruiter.FreeSlots >= 5)
                        {
                            continue ;
                        }
                        recruiter.FreeSlots = recruiter.FreeSlots - 1;
                        recruiter.Level = recruiter.Level + 1;

                await _data.SaveChangesAsync(CancellationToken.None);
               
            }


            return (job.Id);
        }
    }
}
