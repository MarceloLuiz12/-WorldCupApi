using CopaDoMundo.Domain.Auxiliar;
using CopaDoMundo.Domain.Common;
using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.Models_Autenticacao;
using CopaDoMundo.Domain.Interfaces.Auxiliares;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Domain.Interfaces.Service;
using CopaDoMundo.Infra.Context;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CopaDoMundo.Service
{
    public class AutenticacaoService : BaseService, IGerarTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<AppDbContext> _uow;

        public AutenticacaoService(IUserRepository userRepository, IUnitOfWork<AppDbContext> uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<ResultViewBaseModel> GerarTokenAsync(UserInputModel model)
        {
            var usuario = await _userRepository.BuscarUsuarioAsync(model);
            if (usuario == null)
                return AddErros(ServiceResource.UsuarioNaoEncontrado);

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Constantes.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Login),
                    new Claim(ClaimTypes.Role, model.Senha)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return AddResult(tokenHandler.WriteToken(token));
        }

        public async Task<ResultViewBaseModel> CriarUsuarioAsync(CadastrarUsuarioInputModel model)
        {
            var usuario = _userRepository.CriarUsuarioAsync(model);
            if(usuario == null)
                return AddErros(ServiceResource.ErroAoCriarUsuario);

            await _uow.CommitAsync();

            return AddResult(usuario); 
        }
    }
}
