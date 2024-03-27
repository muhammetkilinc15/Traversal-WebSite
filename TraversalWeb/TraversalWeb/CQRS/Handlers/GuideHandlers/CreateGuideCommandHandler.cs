using DataAccessLayer.Concreate;
using MediatR;
using TraversalWeb.CQRS.Commands.GuideCommands;

namespace TraversalWeb.CQRS.Handlers.GuideHandlers
{
	public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
	{
		private readonly Context context;

		public CreateGuideCommandHandler(Context context)
		{
			this.context = context;
		}

		public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
		{
			context.Guides.Add(new EntityLayer.Concreate.Guide
			{
				Name = request.Name,
				Description = request.Description,
				Status = true
			}); 
			await context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
