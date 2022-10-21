namespace CopaDoMundo.Domain.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public UsuarioEntity()
        {

        }

        public UsuarioEntity(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
