using AutoMapper;
using MediatR;
using TriWizardCup.Api.Commands;
using TriWizardCup.DataService.Repositories.Interfaces;
using TriWizardCup.Entities.DbSet;

namespace TriWizardCup.Api.Handlers
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
