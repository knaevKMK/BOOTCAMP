namespace Jobs.Services.Commands.Candidate.Commands
{
    using AutoMapper;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entites;
    using Jobs.Services.Commands.Skill.Commands;
    using Jobs.Services.Commands.Recruiter.Commands;
    using System.Linq;

    public  class AddCandidateCommand: IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public List<SkillCreateCommand> Skills { get; set; }
        public RecruiterCreateCommand Recruiter { get; set; }

    }

    public class AddCandidateCommandHandler : AppRequestHandler<AddCandidateCommand, string>
    {
        protected readonly IMediator _mediator;
        public AddCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper, IMediator mediator) : base(data, mapper)
        {
            _mediator = mediator;
        }

        public override async Task<string> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
        {

            Recruiter recruiter = _data.Recruiters
              .Where(r => r.LastName.Equals(request.Recruiter.LastName) && r.Email.Equals(request.Recruiter.Email) && r.Country.Equals(request.Recruiter.Country))
              .FirstOrDefault();

            if (recruiter == null)
            {

                recruiter = _data.Recruiters.Add(new Recruiter
                {
                    LastName = request.Recruiter.LastName,
                    Email = request.Recruiter.Email,
                    Country = request.Recruiter.Country
                }).Entity;
                await _data.SaveChangesAsync(CancellationToken.None);
            }
            else
            {
                recruiter.Level = recruiter.Level + 1;
                await _data.SaveChangesAsync(CancellationToken.None);
            }
           Candidate candidate =  new Candidate
                 {
                     FirstName = request.FirstName,
                     LastName = request.LastName,
                     Email = request.Email,
                     Bio = request.Bio,
                    BirthDate= request.BirthDate,
                    Recruiter = recruiter
                 };
            foreach (var skill in request.Skills)
            {
                candidate.Skills.Add(new Skill { Name = skill.Name });
            }
            _data.Candidates.Add(candidate);
            await _data.SaveChangesAsync(CancellationToken.None);
         
            return (candidate.Id);
        }
    }
}
