using MediatR;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries.Wizards.v1
{
    public class GetAllWizardsQuery : IRequest<IEnumerable<GetWizardResponse>>
    {
    }
}
