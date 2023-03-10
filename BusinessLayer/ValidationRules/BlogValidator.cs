using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Resim alanı boş geçilemez");
            RuleFor(x => x.BlogImage).MaximumLength(100).WithMessage("Lütfen en fazla 200 karakter giriniz");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Lütfen en az 5 karakter giriniz");
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("Tarih alanı boş geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(200).WithMessage("Lütfen en az 200 karakter giriniz");
            RuleFor(x => x.BlogImage2).NotEmpty().WithMessage("Resim alanı boş geçilemez");
            RuleFor(x => x.BlogImage2).MaximumLength(100).WithMessage("Lütfen en fazla 200 karakter giriniz");
        }
    }
}
