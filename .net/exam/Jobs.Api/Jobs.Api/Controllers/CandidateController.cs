namespace Jobs.Api.Controllers
{
    using Jobs.Services.Commands.Candidate.Commands;
    using Jobs.Services.Commands.Candidate.Query;
    using Jobs.Services.Common.Validators;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("/candidates/")]
    public class CandidateController :ApiController
    {
        private readonly ValidationCandidateCreate _validationRules;
        public CandidateController(IMediator mediator, ValidationCandidateCreate validationRules) : base(mediator)
        {
            _validationRules = validationRules;
        }

        [HttpPost]
        [Route("/candidates/")]
        public async Task<IActionResult> Create(AddCandidateCommand model)
        {
            var validationResult = _validationRules.Validate(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            string id = await _mediator.Send(model);
            return Ok(new { Id = id });
        }

        [HttpGet]
        [Route("/candidates/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (id == null)
            {
                return BadRequest(new { Errors = "Candidate gone" });
            }
            var result = await _mediator.Send(new CandidateByIdQuery { Id = id });
            return Ok(result);
        }
        [HttpPut]
        [Route("/candidates/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, EditCandidateCommand model)
        {
            if (id == null)
            {
                return BadRequest(new { Errors = "Id gone" });
            }
            var validationResult = _validationRules.Validate(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            string _id = await _mediator.Send(model);
            return Ok(new { Id = _id });
        }


        [HttpDelete]
        [Route("/candidates/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (id == null)
            {
                return BadRequest(new { Errors = "Candidate gone" });
            }
            int result = await _mediator.Send(new DeleteCandidateCommand { Id = id });
            return Ok(result);
        }
    }
}
