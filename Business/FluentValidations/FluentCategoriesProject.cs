using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentCategoriesProject : AbstractValidator<CategoriesProject>
    {
        public FluentCategoriesProject()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Maximum 100 karakter girebilirsiniz.");
        }
    }
}
