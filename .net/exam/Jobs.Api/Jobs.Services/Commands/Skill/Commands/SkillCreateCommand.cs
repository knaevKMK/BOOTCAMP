namespace Jobs.Services.Commands.Skill.Commands
{
    using AutoMapper;
    using Jobs.Domain.Entites;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
  public  class SkillCreateCommand : IRequest<string>
    {
        public string Name { get; set; }
    }

    public class SkillCreateCommandHandler : AppRequestHandler<SkillCreateCommand, string>
    {
        public SkillCreateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<string> Handle(SkillCreateCommand request, CancellationToken cancellationToken)
        {
                 Skill skill= new Skill { Name= request.Name};
            try
            {
                _data.Skills.Add(skill);
                await _data.SaveChangesAsync(CancellationToken.None);
                return ("Skill created");

            }
            catch (Exception ex) {
                return "Skill already exist";
            }
        }
    }
}
