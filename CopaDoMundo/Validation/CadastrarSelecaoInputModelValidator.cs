using CopaDoMundo.Domain.DTO_s.InputModels;
using FluentValidation;

namespace CopaDoMundo.Api.Validation
{
    public class CadastrarSelecaoInputModelValidator : AbstractValidator<CadastrarSelecaoInputModel>
    {
        public CadastrarSelecaoInputModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Nome"));;

            RuleFor(x => x.Continente)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Continente"));

            RuleFor(x => x.TitulosMundiais)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ApiResource.TitulosMundiaisInvalido);
        }
    }
}
