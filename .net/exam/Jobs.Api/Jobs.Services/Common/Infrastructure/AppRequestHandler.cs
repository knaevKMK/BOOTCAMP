using AutoMapper;
using Jobs.Services.Common.Interfaces;
using MediatR;
namespace Jobs.Services.Common.Infrastructure
{
using System.Threading.Tasks;
using System.Threading;
 public abstract class AppRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly IApplicaitonDbContext _data;
        protected readonly IConfigurationProvider _mapper;

        protected AppRequestHandler(IApplicaitonDbContext data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper.ConfigurationProvider;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
