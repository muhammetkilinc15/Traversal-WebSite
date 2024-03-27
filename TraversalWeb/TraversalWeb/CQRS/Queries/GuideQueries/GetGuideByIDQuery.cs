using MediatR;
using TraversalWeb.CQRS.Results.GuideResult;

namespace TraversalWeb.CQRS.Queries.GuideQueries
{
	public class GetGuideByIDQuery:IRequest<GetGuideByIDQueryResult>
	{
        public int id { get; set; }
        public GetGuideByIDQuery(int id)
		{
			this.id = id;
		}
	}
}
