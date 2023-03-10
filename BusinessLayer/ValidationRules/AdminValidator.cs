using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(10).WithMessage("En az 10 karakter giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Yönetici rolü boş geçilemez");
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Yönetici adı boş geçilemez");
            RuleFor(x => x.AdminPhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
        }
    }
}
