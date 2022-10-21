using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
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

            if (!string.IsNullOrWhiteSpace(model.Username))
                query =  query.Where(x => x.Username.ToLower().Contains(model.Username.ToLower()));

            if (!string.IsNullOrWhiteSpace(model.Password))
                query = query.Where(x => x.Password.ToLower().Contains(model.Password.ToLower()));


            return  query
                .Select(x => new UserOutPutModel() { Id = x.Id, Username = x.Username, Password = x.Password, Role = x.Role }).FirstOrDefault();
        }
    }
}
