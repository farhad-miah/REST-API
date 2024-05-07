using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace TriWizardCup.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private bool _disposed = false;

        public IWizardRepository Wizards {  get;}

        public IAchievementsRepository Achievements { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Wizards = new WizardRepository(_context, _logger);
            Achievements = new AchievementsRepository(_context, _logger);
        }


        // This method is called after each change to the DB in order to save the changes.
        public async Task<bool> CompleteAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var result = await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while completing the unit of work.");
                await transaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
