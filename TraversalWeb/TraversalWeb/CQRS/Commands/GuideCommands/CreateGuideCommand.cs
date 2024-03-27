﻿using MediatR;

namespace TraversalWeb.CQRS.Commands.GuideCommands
{
	public class CreateGuideCommand:IRequest
	{
		public string Name { get; set; }
		public string? Description { get; set; }

		public bool Status { get; set; }
	}
}