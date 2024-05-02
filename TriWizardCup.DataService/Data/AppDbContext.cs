using TriWizardCup.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace TriWizardCup.DataService.Data
{
    public class AppDbContext : DbContext
    {
        //defining entities
        public virtual DbSet<Wizard> Wizards { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //specified the relationship between the entities
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(d => d.Wizard)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.WizardId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Wizard");
            });
        }
    }
}
