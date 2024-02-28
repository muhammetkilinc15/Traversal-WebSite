using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x=>x.Image1).NotEmpty().WithMessage("Resim boş bırakılamaz");

            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama en az 50 karaktere sahip olmalı");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Açıklama en fazla 1500 karaktere sahip olabilir");

        }
    }
}
