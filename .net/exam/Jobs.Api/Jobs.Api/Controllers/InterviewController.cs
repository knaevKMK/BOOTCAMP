namespace Jobs.Api.Controllers
{
    using Jobs.Services.Commands.Interview;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

     [Route("/interviews")]
    public class InterviewController : ApiController
    {
        public InterviewController(IMediator mediator) : base(mediator)
        {
        }
            [HttpGet]
            public async Task<IActionResult> Active()
            {
                var result = await _mediator.Send(new InterviewGetAllQuery());
                return Ok(result);
            }
        
    }
}
