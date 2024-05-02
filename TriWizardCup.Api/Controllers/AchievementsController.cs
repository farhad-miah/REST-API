using AutoMapper;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Requests;
using TriWizardCup.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TriWizardCup.Api.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{wizardId:guid}")]
        public async Task<IActionResult> GetWizardAchievements(Guid wizardId)
        {
            var wizardAchievements = await _unitOfWork.Achievements.GetWizardAchievementAsync(wizardId);

            if (wizardAchievements is null)
                return NotFound("Achievements not found");

            var result = _mapper.Map<WizardAchievementResponse>(wizardAchievements);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateWizardAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetWizardAchievements), new { wizardId = result.WizardId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateWizardAchievementRequest achievement)
        { 
            if(!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Achievement>(achievement);

            await _unitOfWork.Achievements.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
