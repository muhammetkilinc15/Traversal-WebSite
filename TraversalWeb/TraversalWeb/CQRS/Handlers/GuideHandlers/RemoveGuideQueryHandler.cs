using DataAccessLayer.Concreate;
using MediatR;
using TraversalWeb.CQRS.Commands.GuideCommands;

namespace TraversalWeb.CQRS.Handlers.GuideHandlers
{
    public class RemoveGuideQueryHandler :IRequestHandler<RemoveGuideCommand>
    {
        private readonly Context _context;

        public RemoveGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveGuideCommand request, CancellationToken cancellationToken)
        {
            var value = _context.Guides.Find(request.id);
            if (value!=null)
            {
                _context.Guides.Remove(value);
               await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
