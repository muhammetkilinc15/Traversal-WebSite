using DataAccessLayer.Concreate;
using TraversalWeb.CQRS.Queries.DestinationQueries;
using TraversalWeb.CQRS.Results.DestinationResults;

namespace TraversalWeb.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationIdQeueryHandler
    {
        private readonly Context _context;

        public GetDestinationIdQeueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIQueryResult Handle(GetDestinationByIdQuery p)
        {
            var value = _context.Destinations.Find(p.Id);

            return new GetDestinationByIQueryResult
            {
                DestinationID = value.DestinationID,
                City = value.City,
                DayNight = value.DayNight,
                Price = value.Price,
            };
        }
    }
}
