namespace TriWizardCup.Entities.Dtos.Requests
{
    public class UpdateWizardRequest
    {
        public Guid WizardId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int WizardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
