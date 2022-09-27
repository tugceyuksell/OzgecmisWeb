using Entities;
using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentExperience: AbstractValidator<Experience>
    {
        public FluentExperience()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");

            //RuleFor(x => x.Description).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz."); // Zorunlu alan değil
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Maximum 500 karakter girebilirsiniz.");


        }
    }
}
