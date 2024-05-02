namespace TriWizardCup.Entities.DbSet
{
    public class Wizard : BaseEntity
    {
        public Wizard()
        {
            Achievements= new HashSet<Achievement>();
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int WizardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; } 
    }
}
