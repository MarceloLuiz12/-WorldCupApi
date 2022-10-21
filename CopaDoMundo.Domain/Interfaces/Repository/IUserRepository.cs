using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;

namespace CopaDoMundo.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserOutPutModel> BuscarUsuarioAsync(UserInputModel model);
    }
}
