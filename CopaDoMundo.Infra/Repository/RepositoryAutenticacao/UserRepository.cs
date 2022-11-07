using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
using CopaDoMundo.Domain.Entities;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Infra.Context;

namespace CopaDoMundo.Infra.Repository.RepositoryAutenticacao
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<UserOutPutModel> BuscarUsuarioAsync(UserInputModel model)
         {
            var query =  _dbContext.Usuario.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Login))
                query =  query.Where(x => x.Username.ToLower().Contains(model.Login.ToLower()));

            if (!string.IsNullOrWhiteSpace(model.Senha))
                query = query.Where(x => x.Password.ToLower().Contains(model.Senha.ToLower()));


            return  query
                .Select(x => new UserOutPutModel() { Id = x.Id, Login = x.Username, Senha = x.Password, Cargo = x.Role }).FirstOrDefault();
        }

        public async Task<UsuarioEntity> CriarUsuarioAsync(CadastrarUsuarioInputModel model)
        {
            var context =  _dbContext.Usuario;

            var usuarioExiste = context.Where(x => x.Username.Contains(model.Login)).FirstOrDefault();

            if (usuarioExiste is not null)
                return null;

            var result = new UsuarioEntity(model.Login, model.Senha, model.Cargo);

            await context.AddAsync(result);

            return result;
        }
    }
}
