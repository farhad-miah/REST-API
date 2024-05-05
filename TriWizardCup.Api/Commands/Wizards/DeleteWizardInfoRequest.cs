using MediatR;

namespace TriWizardCup.Api.Commands.Wizards
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
