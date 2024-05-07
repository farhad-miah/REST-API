using MediatR;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries.Wizards.v2
{
    public class GetAllWizardsQuery : IRequest<IEnumerable<GetWizardResponse>>
    {
    }
}
