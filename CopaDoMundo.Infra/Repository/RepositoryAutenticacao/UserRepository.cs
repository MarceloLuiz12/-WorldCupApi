using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;

namespace CopaDoMundo.Infra.Repository.RepositoryAutenticacao
{
    public class UserRepository
    {
        public static UserModel BuscarUsuario(string username, string password)
        {
            var users = new List<UserModel>
            {
                new() {Id = 1, Username = "marcelo", Password = "marcelo", Role = "manager"},
                new() {Id = 2, Username = "sabrina", Password = "sabrina", Role =  "employee"}
            };

            return users
                .FirstOrDefault(x => x.Username ==  username 
                                                 && x.Password == password);
        }
    }
}
