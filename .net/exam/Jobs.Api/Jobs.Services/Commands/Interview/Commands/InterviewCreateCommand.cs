
namespace Jobs.Services.Commands.Interview.Commands
{
    using MediatR;
    using Jobs.Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using AutoMapper;
    using System.Threading;
    using Jobs.Services.Commands.Recruiter.Commands;
    using System;

    public    class InterviewCreateCommand : IRequest<string>
    {
        public Job Job { get; set; }
    }

    public class InterviewCreateCommandHandler : AppRequestHandler<InterviewCreateCommand, string>
    {
        protected readonly IMediator _mediator;
        public InterviewCreateCommandHandler(IApplicaitonDbContext data, IMapper mapper, IMediator mediator) : base(data, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<string> Handle(InterviewCreateCommand request, CancellationToken cancellationToken)
        {
            var candidatesId = new HashSet<string>();
            foreach (var skill in request.Job.Skills)
            {
              candidatesId.Concat(_data.Candidates
                  .Where(c => c.Skills.Contains(skill) && c.Recruiter.FreeSlots >0)
                  .Select(c=>c.Id)
                  .ToHashSet());
            }
            foreach (var candidateId in candidatesId)
            {
                try
                {
                    Interview interview = new Interview {
                        JobId = request.Job.Id,
                        CandidateId = candidateId
                    };
                    _data.Interviews.Add(interview);
                    bool decrementFreeSlots = await _mediator.Send(new RecruiterDecreaseFreeSlots { CandidateId = candidateId });
                 await   _data.SaveChangesAsync(CancellationToken.None);
                }
                catch (Exception e) { 
                
                }
            }
           
            return ("Interviews created");
        }
    }
}
