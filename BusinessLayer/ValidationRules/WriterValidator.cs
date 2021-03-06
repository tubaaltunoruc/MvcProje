using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanı boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Lütfen en az 2 karekter giriş yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");
            RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa A-a harfi kullanılmalıdır");
           
        }
        private bool IsAboutValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[a,A])");
                return regex.IsMatch(arg);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
