using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands.Wizards.v2;
using TriWizardCup.DataService.Repositories.Interfaces;

namespace TriWizardCup.Api.Handlers.Wizards.v2
{
    public class DeleteWizardInfoHandler : BaseHandler, IRequestHandler<DeleteWizardInfoRequest, bool>
    {
        public DeleteWizardInfoHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Handle(DeleteWizardInfoRequest request, CancellationToken cancellationToken)
        {
            var wizard = await _unitOfWork.Wizards.GetById(request.WizardId);

            if (wizard is null)
                return false;

            await _unitOfWork.Wizards.Delete(request.WizardId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
