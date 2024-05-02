using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace TriWizardCup.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IWizardRepository Wizards {  get;}

        public IAchievementsRepository Achievements { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");

            Wizards = new WizardRepository(_context, logger);
            Achievements = new AchievementsRepository(_context, logger);
        }


        //This method is called after each change to the DB in order to save the changes.
        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
