using TriWizardCup.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TriWizardCup.DataService.Data
{
    // Using base class of IdentityDbContext instead of DbContext to generate identity tables
    public class AppDbContext : IdentityDbContext
    {
        // Defining entities
        public virtual DbSet<Wizard> Wizards { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specified the relationship between the entities
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
