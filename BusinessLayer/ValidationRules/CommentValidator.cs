using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("En az 4 karakter giriniz");
            RuleFor(x => x.CommentText).MinimumLength(4).WithMessage("En az 4 karakter giriniz");
            RuleFor(x => x.CommentText).MaximumLength(300).WithMessage("En fazla 300 karakter giriniz");
            RuleFor(x => x.Mail).MinimumLength(4).WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x => x.Mail).MinimumLength(4).WithMessage("Mail kısmı boş geçilemez");

        }
    }
}
