namespace Jobs.Api.Controllers
{
    using Jobs.Services.Commands.Recruiter.Query;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("/recruiters")]
    public class RecruiterController : ApiController
    {
        public RecruiterController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? level)
        {
            if (level == null)
            {
                return Ok(await _mediator.Send(new RecruiterGetAllWithCandidatesQuery()));
            }
            var result = await _mediator.Send(new RecruiterByLevelQuery { Level = level });
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllWithAvailebleCandidates()
        //{
        //    var result = await _mediator.Send(new RecruiterGetAllWithCandidatesQuery());
        //    return Ok(result);
        //}
    }
}
