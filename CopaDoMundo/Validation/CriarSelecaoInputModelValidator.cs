using CopaDoMundo.Domain.DTO_s.InputModels;
using FluentValidation;

namespace CopaDoMundo.Api.Validation
{
    public class CriarSelecaoInputModelValidator : AbstractValidator<CriarUsuarioInputModel>
    {
        public CriarSelecaoInputModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Login"));

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Senha"));

            RuleFor(x => x.Cargo)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Cargo"));
        }
    }
}
