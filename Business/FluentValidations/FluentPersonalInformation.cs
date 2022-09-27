using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentPersonalInformation : AbstractValidator<PersonalInformation>
    {
        public FluentPersonalInformation()
        {
            RuleFor(x => x.NameSurname).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.NameSurname).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.Licence).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Licence).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.Email).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Email).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.Phone).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Phone).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.Address).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Address).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.LinkedIn).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.LinkedIn).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.Medium).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Medium).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.GitHub).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.GitHub).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x => x.DrivingLicense).MinimumLength(1).WithMessage("Minimum 1 karakter girebilirsiniz.");
            RuleFor(x => x.DrivingLicense).MaximumLength(1).WithMessage("Maximum 1 karakter girebilirsiniz.");
        }
    }
}
