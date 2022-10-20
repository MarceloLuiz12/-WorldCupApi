using CopaDoMundo.Domain.DTO_s.InputModels;
using FluentValidation;

namespace CopaDoMundo.Api.Validation
{
    public class AlterarSelecaoInputModelValidator : AbstractValidator<AlterarSelecaoInputModel>
    {
        public AlterarSelecaoInputModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ApiResource.IdInvalido);

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Nome"));

            RuleFor(x => x.Continente)
                .NotEmpty()
                .WithMessage(string.Format(ApiResource.CampoVazio, "Continente"));

            RuleFor(x => x.TitulosMundiais)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ApiResource.TitulosMundiaisInvalido);
        }
    }
}
