using DataAccessLayer.Concreate;
using MediatR;
using TraversalWeb.CQRS.Queries.DestinationQueries;
using TraversalWeb.CQRS.Queries.GuideQueries;
using TraversalWeb.CQRS.Results.GuideResult;

namespace TraversalWeb.CQRS.Handlers.GuideHandlers
{
	public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
	{
		private readonly Context context;

		public GetGuideByIDQueryHandler(Context context)
		{
			this.context = context;
		}

		async Task<GetGuideByIDQueryResult> IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>.Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
		{
			var values = await context.Guides.FindAsync(request.id);
			return new GetGuideByIDQueryResult
			{
				GuideID = values.GuideID,
				Description = values.Description,
				Name = values.Name,
			};
		}
	}
}
