using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TriWizardCup.DataService.Data;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;

namespace TriWizardCup.DataService.Repositories
{
    public class WizardRepository : GenericRepository<Wizard>, IWizardRepository
    {
        public WizardRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Wizard>> All()
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
                _logger.LogError(e, "{Repo} All function error", typeof(WizardRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                // obtain entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result is null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(WizardRepository));
                throw;
            }
        }


        public override async Task<bool> Update(Wizard wizard)
        {
            try 
            {
                // obtain entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == wizard.Id);

                if (result is null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.WizardNumber = wizard.WizardNumber;
                result.FirstName = wizard.FirstName;
                result.LastName = wizard.LastName;
                result.DateOfBirth = wizard.DateOfBirth;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(WizardRepository));
                throw;
            }
        }
    }
}
