using CopaDoMundo.Domain.DTO_s.InputModels;

namespace CopaDoMundo.Tests.Configurations.MockServices
{
    public class ValidatorApiMock
    {
        public static IEnumerable<object[]> AlterarSelecaoInputModel()
        {
            yield return new object[]
                    {new AlterarSelecaoInputModel{ Id = -2, Nome = "Teste",Continente = "Ámérica do Sul", TitulosMundiais = 2}, false, "Id informado é inválido !"};

            yield return new object[]
                    {new AlterarSelecaoInputModel{ Id = 30,Continente = "Ámérica do Sul", TitulosMundiais = 2}, false, "O campo 'Nome' não pode ser vazio !"};

            yield return new object[]
                    {new AlterarSelecaoInputModel{ Id = 31,Nome = "TesteMarcleo", Continente = "Ámérica do Sul", TitulosMundiais = -2}, false, "Titulos mundiais inválido !"};

            yield return new object[]
                    {new AlterarSelecaoInputModel{ Id = 32,Nome = "TesteAlterar",TitulosMundiais = 2}, false, "O campo 'Continente' não pode ser vazio !"};

            yield return new object[]
                    {new AlterarSelecaoInputModel{ Id = 33, Nome = "TesteApi",Continente = "Ámérica do Sul", TitulosMundiais = 2}, true, null};
        }

        public static IEnumerable<object[]> CadastrarSelecaoInputModel()
        {
            yield return new object[]
                    {new CadastrarSelecaoInputModel{ Continente = "Ámérica do Sul", TitulosMundiais = 2}, false, "O campo 'Nome' não pode ser vazio !"};

            yield return new object[]
                    {new CadastrarSelecaoInputModel{ Nome = "TesteMarcleo", Continente = "Ámérica do Sul", TitulosMundiais = -2}, false, "Titulos mundiais inválido !"};

            yield return new object[]
                    {new CadastrarSelecaoInputModel{ Nome = "TesteAlterar",TitulosMundiais = 2}, false, "O campo 'Continente' não pode ser vazio !"};

            yield return new object[]
                    {new CadastrarSelecaoInputModel{ Nome = "TesteApi",Continente = "Ámérica do Sul", TitulosMundiais = 2}, true, null};
        }

        public static IEnumerable<object[]> CadastrarUsuarioInputModel()
        {
            yield return new object[]
                    {new CadastrarUsuarioInputModel{Login = "TESTE", Senha = "TESTE"}, false, "O campo 'Cargo' não pode ser vazio !"};

            yield return new object[]
                    {new CadastrarUsuarioInputModel{Senha = "TESTE", Cargo = "GERENTE" }, false, "O campo 'Login' não pode ser vazio !"};

            yield return new object[]
                    {new CadastrarUsuarioInputModel{Login = "TESTE", Cargo = "GERENTE"}, false, "O campo 'Senha' não pode ser vazio !"};

            yield return new object[]
                    {new CadastrarUsuarioInputModel{Login = "TESTE", Senha = "TESTE", Cargo = "Gerente"},true, null };
        }

    }
}
