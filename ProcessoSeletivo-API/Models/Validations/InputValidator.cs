using FluentValidation;

namespace ProcessoSeletivo_API.Models.Validations
{
    public class InputValidator : AbstractValidator<CandidatoInputModel>
    {
        public InputValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.CPF).NotEmpty();
            RuleFor(c => c.Skils).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}
