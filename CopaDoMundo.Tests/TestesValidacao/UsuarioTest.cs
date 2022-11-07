using CopaDoMundo.Api.Validation;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Tests.Configurations.MockServices;
using Xunit;

namespace CopaDoMundo.Tests.TestesValidacao
{
    public class UsuarioTest
    {
        private readonly CriarUsuarioInputModelValidator _validatorCriarUsuario = new();

        [Trait("TestesValidacao", "UsuarioTest")]
        [Theory(DisplayName = "CriarUsuario: Sucesso")]
        [MemberData(nameof(ValidatorApiMock.CadastrarUsuarioInputModel), MemberType = typeof(ValidatorApiMock))]
        public void CadsatrarUsuario(CadastrarUsuarioInputModel model, bool esperado, string mensagem)
        {
            var result = _validatorCriarUsuario.Validate(model);

            Assert.Equal(esperado, result.IsValid);
            Assert.Equal(mensagem, result.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }
}
