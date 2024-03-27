using MediatR;
using TraversalWeb.CQRS.Results.GuideResult;

namespace TraversalWeb.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
