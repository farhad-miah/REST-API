using MediatR;

namespace TriWizardCup.Api.Commands.Wizards.v1
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
