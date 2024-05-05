using MediatR;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.Commands.Wizards
{
    public class UpdateWizardInfoRequest : IRequest<bool>
    {
        public UpdateWizardRequest UpdateRequest { get; }

        public UpdateWizardInfoRequest(UpdateWizardRequest updateRequest)
        {
            UpdateRequest = updateRequest;
        }
    }
}
