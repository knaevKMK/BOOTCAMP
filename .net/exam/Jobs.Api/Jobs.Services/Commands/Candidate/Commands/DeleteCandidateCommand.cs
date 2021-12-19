
namespace Jobs.Services.Commands.Candidate.Commands
{
    using AutoMapper;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
public    class DeleteCandidateCommand : IRequest<int>
    {
        public string Id { get; set; }

    }
    public class DeleteCandidateCommandHandler : AppRequestHandler<DeleteCandidateCommand, int>
    {
        public DeleteCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }



        public override async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            Domain.Entites.Candidate candidate = _data.Candidates.FirstOrDefault(c => c.Id.Equals(request.Id));
            if (candidate == null)
            {
                return 0;
            }
            candidate.IsDeleted = true;
            int result = await _data.SaveChangesAsync(CancellationToken.None);
            return result;
        }
    }
}
