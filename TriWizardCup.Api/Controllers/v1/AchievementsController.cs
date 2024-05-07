using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TriWizardCup.Api.Commands.Achievements.v1;
using TriWizardCup.Api.Queries.Achievements.v1;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.Controllers.v1
{
    // Added version number here for API and also set flag for Deprecation attribute to true so response header shows this version is deprecated.
    [ApiVersion(1, Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet("{wizardId:guid}", Name = "GetWizardAchievements")]
        public async Task<IActionResult> GetWizardAchievements(Guid wizardId)
        {
            var query = new GetWizardsAchievementsQuery(wizardId);

            var result = await _mediator.Send(query);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost("", Name = "AddAchievement")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateWizardAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new AddWizardAchievementInfoRequest(achievement);

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetWizardAchievements), new { wizardId = result.WizardId }, result);
        }

        [HttpPut("", Name = "UpdateAchievement")]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateWizardAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateWizardAchievementInfoRequest(achievement);

            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
