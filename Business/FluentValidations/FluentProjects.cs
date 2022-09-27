using Entities.DTO.Projects;
using FluentValidation;
namespace Business.FluentValidations
{
    public class FluentProjects : AbstractValidator<DtoProjectsInsert>
    {
        public FluentProjects()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Name).MaximumLength(250).WithMessage("Maximum 250 karakter girebilirsiniz.");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Maximum 500 karakter girebilirsiniz.");
        }
    }
}
