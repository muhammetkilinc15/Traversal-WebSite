using DataAccessLayer.Concreate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using TraversalWeb.CQRS.Queries.GuideQueries;
using TraversalWeb.CQRS.Results.GuideResult;

namespace TraversalWeb.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                Description = x.Description,
                GuideID=x.GuideID,
                Name=x.Name,
                Image=x.Image
            }).AsNoTracking().ToListAsync();
        }
    }
}
