namespace TriWizardCup.Entities.DbSet
{
    public class Achievement : BaseEntity
    {
        public int DuelsWon { get; set; }
        public int TopThreeFinishes { get; set; }
        public int TotalEnemiesDefeated { get; set; }
        public int TriWizardCupWins { get; set; }
        public Guid WizardId { get; set; }

        public virtual Wizard? Wizard { get; set; }
    }
}
