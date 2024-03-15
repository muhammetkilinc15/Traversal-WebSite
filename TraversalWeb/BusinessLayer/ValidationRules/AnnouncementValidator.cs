using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
	{
		public AnnouncementValidator()
		{
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
			RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş bırakılamaz");

			RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık  en az 5 karakter içermeli");
			RuleFor(x => x.Content).MinimumLength(20).WithMessage("İçerik en az 20 karakter içermeli");

			RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık  en fazla 100 karakter içermeli");
			RuleFor(x => x.Content).MaximumLength(500).WithMessage("İçerik en fazla 500 karakter içermeli");
		}
	}
}
