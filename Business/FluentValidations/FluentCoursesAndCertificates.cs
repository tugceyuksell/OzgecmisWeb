using FluentValidation;
namespace Business.FluentValidations
{
    public class FluentCoursesAndCertificates: AbstractValidator<CoursesAndCertificates>
    {
        public FluentCoursesAndCertificates()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 kaarkter girebilirsiniz.");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Maximum 200 karakter girebilirsiniz.");
            RuleFor(x =>x.Description).MinimumLength(3).WithMessage("Minimum 3 kaarkter girebilirsiniz.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Maximum 500 karakter girebilirsiniz.");

        }
    }
}
