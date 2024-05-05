using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriWizardCup.Api.Commands;
using TriWizardCup.Api.Queries;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.Controllers
{
    public class WizardsController : BaseController
    {
        public WizardsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet]
        [Route("{wizardId:Guid}")]
        public async Task<IActionResult> GetWizard(Guid wizardId)
        {
            var query = new GetWizardQuery(wizardId);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound();

            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWizards()
        {
            //create a query
            var query = new GetAllWizardsQuery();

            //await result from the handler passed by MediatR
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddWizard([FromBody] CreateWizardRequest wizard)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //create command
            var command = new CreateWizardInfoRequest(wizard);

            //await result from handler from MediatR
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetWizard), new { wizardId = result.WizardId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateWizard([FromBody] UpdateWizardRequest wizard)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateWizardInfoRequest(wizard);

            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{wizardId:guid}")]
        public async Task<IActionResult> DeleteWizard(Guid wizardId)
        { 
            var command = new DeleteWizardInfoRequest(wizardId);

            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
