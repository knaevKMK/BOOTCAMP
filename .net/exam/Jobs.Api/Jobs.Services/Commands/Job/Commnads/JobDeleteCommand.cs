namespace Jobs.Services.Commands.Job.Commnads
{

using AutoMapper;
using Jobs.Services.Common.Infrastructure;
using Jobs.Services.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
public class JobDeleteCommand : IRequest<int>
    {
        public string Id { get; set; }

    }
    public class DeleteJobCommandHandler : AppRequestHandler<JobDeleteCommand, int>
    {
        public DeleteJobCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
        {
        }



        public override async Task<int> Handle(JobDeleteCommand request, CancellationToken cancellationToken)
        {
            Domain.Entites.Job job = _data.Jobs.FirstOrDefault(c => c.Id.Equals(request.Id));
            if (job == null)
            {
                return 0;
            }
            job.IsDeleted = true;
            int result = await _data.SaveChangesAsync(CancellationToken.None);
            return result;
        }
    }
}
