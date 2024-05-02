using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriWizardCup.Entities.Dtos.Requests
{
    public class CreateWizardRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int WizardNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
