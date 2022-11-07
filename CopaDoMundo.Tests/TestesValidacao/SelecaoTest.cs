using CopaDoMundo.Api.Validation;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Tests.Configurations.MockServices;
using Xunit;

namespace CopaDoMundo.Tests.TestesValidacao
{
    public class SelecaoTest
    {
        private readonly AlterarSelecaoInputModelValidator _validatorAlterarSelecao = new();
        private readonly CadastrarSelecaoInputModelValidator _validatorCadastrarSelecao = new();

        [Trait("TestesValidacao", "SelecaoTest")]
        [Theory(DisplayName = "AlterarSelecao: Sucesso")]
        [MemberData(nameof(ValidatorApiMock.AlterarSelecaoInputModel), MemberType = typeof(ValidatorApiMock))]
        public void AlterarSelecao(AlterarSelecaoInputModel model, bool esperado, string mensagem)
        {
            var result = _validatorAlterarSelecao.Validate(model);

            Assert.Equal(esperado, result.IsValid);
            Assert.Equal(mensagem, result.Errors.FirstOrDefault()?.ErrorMessage);
        }

        [Trait("TestesValidacao", "SelecaoTest")]
        [Theory(DisplayName = "CadastrarSelecao: Sucesso")]
        [MemberData(nameof(ValidatorApiMock.CadastrarSelecaoInputModel), MemberType = typeof(ValidatorApiMock))]
        public void CadastrarSelecao(CadastrarSelecaoInputModel model, bool esperado, string mensagem)
        {
            var result = _validatorCadastrarSelecao.Validate(model);

            Assert.Equal(esperado, result.IsValid);
            Assert.Equal(mensagem, result.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}
