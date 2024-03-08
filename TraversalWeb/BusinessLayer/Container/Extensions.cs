using BusinessLayer.Abstract;
using BusinessLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
	// Dependcy Inejction için kullandık <<<----
	public static class Extensions
	{
		public static void ContainerDependencies(IServiceCollection Services)
		{		
			Services.AddScoped<Context>();
			Services.AddScoped<IDestinationDal, EfDestinationDal>();
			Services.AddScoped<IDestinationService, DestinationManager>();

			Services.AddScoped<IReservationDal, EfReservationDal>();
			Services.AddScoped<IReservationService, ReservationManager>();

			Services.AddScoped<ICommentDal, EfCommentDal>();
			Services.AddScoped<ICommentService, CommentManager>();

			Services.AddScoped<IAppUserDal, EfAppUserDal>();
			Services.AddScoped<IAppUserService, AppUserManager>();

			Services.AddScoped<IGuideDal, EfGuideDal>();
			Services.AddScoped<IGuideService, GuideManager>();
		}
	}
}
