using MediatR;

namespace TriWizardCup.Api.Commands
{
    public class DeleteWizardInfoRequest : IRequest<bool>
    {
        public Guid WizardId { get; }
        public DeleteWizardInfoRequest(Guid wizardId) 
        {
            WizardId = wizardId;
        }
    }
}
