using DataAccessLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using TraversalWeb.CQRS.Queries.DestinationQueries;
using TraversalWeb.CQRS.Results.DestinationResults;

namespace TraversalWeb.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult()
            {
                ID = x.DestinationID,
                Capacity = x.Capacity,
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
