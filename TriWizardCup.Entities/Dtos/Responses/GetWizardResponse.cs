namespace TriWizardCup.Entities.Dtos.Responses
{
    public class GetWizardResponse
    {
        public Guid WizardId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int WizardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
