using MediatR;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries.Wizards
{
    public class GetAllWizardsQuery : IRequest<IEnumerable<GetWizardResponse>>
    {
    }
}
