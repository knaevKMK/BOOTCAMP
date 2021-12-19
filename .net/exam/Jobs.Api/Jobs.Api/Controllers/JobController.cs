
namespace Jobs.Api.Controllers
{
    using Jobs.Services.Commands.Job.Commnads;
    using Jobs.Services.Commands.Job.Query;
    using Jobs.Services.Common.Validators;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    [Route("/jobs")]
    public class JobController : ApiController
    {
        private readonly ValidationCreateJob _validationRules;
        public JobController(IMediator mediator, ValidationCreateJob validationRules) : base(mediator)
        {
            _validationRules = validationRules;
        }

        [HttpGet]
        public async Task<IActionResult> GetBySkillName([FromQuery] string skillName)
        {
            if (skillName == null)
            {
                return BadRequest(new { Errors = "Skill Name gone" });
            }
            var result = await _mediator.Send(new JobBySkillQuery { SkillName = skillName});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddJobCommand model)
        {
            var validationResult = _validationRules.Validate(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            string id = await _mediator.Send(model);
            return Ok(new { Id = id });
        }

        [HttpDelete]
        [Route("/jobs/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (id == null)
            {
                return BadRequest(new { Errors = "Job gone" });
            }
            var result = await _mediator.Send(new JobDeleteCommand { Id = id });
            return Ok(result);
        }
    }
}
