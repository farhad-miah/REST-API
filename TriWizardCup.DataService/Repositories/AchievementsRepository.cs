using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TriWizardCup.DataService.Repositories
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
    {
        public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetWizardAchievementAsync(Guid wizardId)
        {
            try
            {
                //include the wizard object returned with the query
                return await _dbSet.Include(x => x.Wizard)
                    .FirstOrDefaultAsync(x => x.WizardId == wizardId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetWizardAchievementAsync function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(AchievementsRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                // Obtain entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementsRepository));
                throw;
            }
        }


        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                // Obtain entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

                if (result is null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.TotalEnemiesDefeated = achievement.TotalEnemiesDefeated;
                result.TopThreeFinishes = achievement.TopThreeFinishes;
                result.DuelsWon = achievement.DuelsWon;
                result.TriWizardCupWins = achievement.TriWizardCupWins;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(AchievementsRepository));
                throw;
            }
        }
    }
}
