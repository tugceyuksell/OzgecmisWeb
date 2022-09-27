using Entities.DTO.AboutMe;
using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentAboutMe : AbstractValidator<DtoAboutMeInsert>
    {
        public FluentAboutMe()
        {
            RuleFor(x => x.CoverLetter).MinimumLength(3).WithMessage("Mininum 3 karakter girebilirsiniz.");
            RuleFor(x => x.CoverLetter).MaximumLength(300).WithMessage("Maximum 300 karakter girebilirsiniz.");
        }
    }

}
