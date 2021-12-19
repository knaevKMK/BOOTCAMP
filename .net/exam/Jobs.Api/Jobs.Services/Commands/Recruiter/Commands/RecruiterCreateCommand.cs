
namespace Jobs.Services.Commands.Recruiter.Commands
{
    using AutoMapper;
    using Jobs.Domain.Entites;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
public    class RecruiterCreateCommand : IRequest<string>
    {
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }

    public class RecruiterCreateCommandHandler : AppRequestHandler<RecruiterCreateCommand, string>
    {
        public RecruiterCreateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }

        public override async Task<string> Handle(RecruiterCreateCommand request, CancellationToken cancellationToken)
        {
            Recruiter recruiter = _data.Recruiters
                .Where(r => r.LastName.Equals(request.LastName) && r.Email.Equals(request.Email) && r.Country.Equals(request.Country))
                .FirstOrDefault();
            if (recruiter == null)
            {
                recruiter = _mapper.CreateMapper().Map<Recruiter>(request);
                _data.Recruiters.Add(recruiter);

            }
            else { 
            recruiter.Level = recruiter.Level + 1;
            }


            await _data.SaveChangesAsync(CancellationToken.None);
            return (recruiter.Id);
        }
    }
}
