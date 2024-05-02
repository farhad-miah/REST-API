using AutoMapper;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TriWizardCup.Api.Controllers
{
    public class WizardsController : BaseController
    {
        public WizardsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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

        [HttpPost("")]
        public async Task<IActionResult> AddWizard([FromBody] CreateWizardRequest wizard)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Wizard>(wizard);

            await _unitOfWork.Wizards.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetWizard), new { wizardId = result.Id }, result);
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

        [HttpGet]
        public async Task<IActionResult> GetAllWizards()
        {
            var wizards = await _unitOfWork.Wizards.All();

            return Ok(_mapper.Map<IEnumerable<GetWizardResponse>>(wizards));
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
