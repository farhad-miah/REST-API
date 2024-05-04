using AutoMapper;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Runtime.CompilerServices;
using TriWizardCup.Api.Queries;
using TriWizardCup.Api.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TriWizardCup.Api.Controllers
{
    public class WizardsController : BaseController
    {
        private readonly IMediator _mediator;

        public WizardsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{wizardId:Guid}")]
        public async Task<IActionResult> GetWizard(Guid wizardId)
        {
            var wizard = await _unitOfWork.Wizards.GetById(wizardId);

            if (wizard is null)
                return NotFound();

            var result = _mapper.Map<GetWizardResponse>(wizard);

            return Ok(result);
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

            var result = _mapper.Map<Wizard>(wizard);

            await _unitOfWork.Wizards.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{wizardId:guid}")]
        public async Task<IActionResult> DeleteWizard(Guid wizardId)
        { 
            var wizard = await _unitOfWork.Wizards.GetById(wizardId);

            if (wizard is null)
                return NotFound();

            await _unitOfWork.Wizards.Delete(wizardId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
