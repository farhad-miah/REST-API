namespace TriWizardCup.Entities.Dtos.Responses
{
    public class WizardAchievementResponse
    {
        public Guid WizardId { get; set; }
        public int WorldChampionship { get; set; }
        public int TotalEnemiesDefeated { get; set; }
        public int PodiumPosition { get; set; }
        public int Wins { get; set; }
    }
}
