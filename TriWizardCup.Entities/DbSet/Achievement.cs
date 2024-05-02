namespace TriWizardCup.Entities.DbSet
{
    public class Achievement : BaseEntity
    {
        public int DuelsWon { get; set; }
        public int PodiumPosition { get; set; }
        public int TotalEnemiesDefeated { get; set; }
        public int WorldChampionship { get; set; }
        public Guid WizardId { get; set; }

        public virtual Wizard? Wizard { get; set; }
    }
}
