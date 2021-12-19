namespace Jobs.Api.Controllers
{
    using Jobs.Services.Commands.Skill.Query;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    
    public class SkillController : ApiController
    {
        public SkillController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("/skills/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (id == null)
            {
                return BadRequest(new { Errors = "Skills  gone" });
            }
            var result = await _mediator.Send(new SkillByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        [Route("/skills/active")]
        public async Task<IActionResult> Active()
        {
            var result = await _mediator.Send(new SkillActiveQuery());
            return Ok(result);
        }
    }
}
