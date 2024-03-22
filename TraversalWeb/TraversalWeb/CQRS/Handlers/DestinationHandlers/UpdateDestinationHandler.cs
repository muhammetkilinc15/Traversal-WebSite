using DataAccessLayer.Concreate;
using TraversalWeb.CQRS.Commands.DestinationCommands;

namespace TraversalWeb.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationHandler
    {
        private readonly Context _context;

        public UpdateDestinationHandler(Context context)
        {
            _context = context;
        }

        public void Update(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.ID);
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
