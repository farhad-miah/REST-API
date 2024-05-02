using TriWizardCup.Entities.DbSet;

namespace TriWizardCup.DataService.Repositories.Interfaces
{
    public interface IAchievementsRepository : IGenericRepository<Achievement>
    {
        Task<Achievement?> GetWizardAchievementAsync(Guid wizardId);
    }
}
