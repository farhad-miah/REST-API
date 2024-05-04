using MediatR;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.Queries
{
    public class GetAllWizardsQuery : IRequest<IEnumerable<GetWizardResponse>>
    {
    }
}
