using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUnitOfWork;
using BusinessLayer.Concreate;
using BusinessLayer.Concreate.UnitOfWorkConcreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
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

            Services.AddScoped<IExcelService, ExcellManager>();
            Services.AddScoped<IPdfService, PdfManager>();

			Services.AddScoped<IContactUsDal, EfContactUsDal>();
			Services.AddScoped<IContactUsService, ContactUsManager>();

            Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            Services.AddScoped<IAnnouncementService, AnnouncementManager>();


			Services.AddScoped<IAccountService,AccountManager>();
			Services.AddScoped<IAccountDal, EfAccountDal>();

		}



		public static void CustomerValidator(this IServiceCollection services)
		{
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();

        }
    }
}
