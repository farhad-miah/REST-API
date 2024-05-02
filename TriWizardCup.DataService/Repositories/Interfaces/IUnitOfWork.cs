namespace TriWizardCup.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IWizardRepository Wizards { get; }
        IAchievementsRepository Achievements { get; }

        Task<bool> CompleteAsync();
    }
}
