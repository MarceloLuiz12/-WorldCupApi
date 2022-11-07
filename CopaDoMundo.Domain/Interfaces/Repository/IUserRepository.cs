using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
using CopaDoMundo.Domain.Entities;

namespace CopaDoMundo.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserOutPutModel> BuscarUsuarioAsync(UserInputModel model);
        Task<UsuarioEntity> CriarUsuarioAsync(CadastrarUsuarioInputModel model);
    }
}
