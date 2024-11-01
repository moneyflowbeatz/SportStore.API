using SportStore.API.Entities;
using FluentValidation;
namespace SportStore.API.Validations
{
    public class RoleFluentValidator : AbstractValidator<User>
    {
        public RoleFluentValidator()
        {
            RuleFor(u => u.Name).Must(StartsWithCapitalLetter).WithMessage("Имя роли должно начинаться с заглавной буквы");
        }
        
        private bool StartsWithCapitalLetter(string role)
        {
            return char.IsUpper(role[0]);
        }
}
}