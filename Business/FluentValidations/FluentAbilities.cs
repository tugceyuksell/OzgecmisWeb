using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.FluentValidations
{
    public class FluentAbilities : AbstractValidator<Abilities>
    {
        public FluentAbilities()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Mininum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            //RuleFor(x=>x.Rating).Must(SayiKontrol).WithMessage("Minimum 1 ve Maximumum 100 Arasında Değer Girelebilir.").When(x => x.Rating < 1).WithMessage("Minimum 1 ve Maximumum 100 Arasında Değer Girelebilir.");
        }

        private bool SayiKontrol(byte price)
        {
            // Girilen veri Kesinlikle Sayı olmalı ve Maximum 3 haneli olmalıdır.
            Regex regex = new Regex(@"\d{3}");
            return regex.IsMatch(price.ToString());
        }
    }
}
