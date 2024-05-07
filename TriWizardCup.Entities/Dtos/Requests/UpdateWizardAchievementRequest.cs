using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriWizardCup.Entities.Dtos.Requests
{
    public class UpdateWizardAchievementRequest
    {
        public Guid WizardId { get; set; }
        public int TriWizardCupWins { get; set; }
        public int TotalEnemiesDefeated { get; set; } 
        public int TopThreeFinishes { get; set; }
        public int Wins { get; set; }
    }
}
