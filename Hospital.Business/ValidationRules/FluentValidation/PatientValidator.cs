using FluentValidation;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.ValidationRules.FluentValidation
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(x => x.TCKN).NotEmpty().WithMessage("TCKN alanı boş geçilemez");
            RuleFor(x => x.TCKN).Length(11).WithMessage("TCKN alanı 11 karakter olmalıdır");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Hasta adı boş geçilemez");
        }
    }
}
