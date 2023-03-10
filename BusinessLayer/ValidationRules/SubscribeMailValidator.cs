using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SubscribeMailValidator: AbstractValidator<SubscribeMail>
    {
        public SubscribeMailValidator()
        {
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("En az 10 karakter giriniz");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("En fazla 30 karakter giriniz");
            
        }
    }
}
