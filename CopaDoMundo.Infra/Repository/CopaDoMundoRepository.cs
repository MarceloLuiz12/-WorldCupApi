using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Entities;
using CopaDoMundo.Domain.Interfaces.Repository;
using CopaDoMundo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CopaDoMundo.Infra.Repository
{
    public class CopaDoMundoRepository : ICopaDoMundoRepository
    {
        private readonly AppDbContext _dbContext;

        public CopaDoMundoRepository(AppDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<List<CopaDoMundoOutPutModel>> BuscarSelecaoAsync()
           => await _dbContext.Selecao.Select(x => new CopaDoMundoOutPutModel
           {
               Id = x.Id,
               Nome = x.Nome,
               TitulosMundiais = x.TitulosMundiais,
               Continente = x.Continente
           })
           .ToListAsync();

        public async Task<CopaDoMundoOutPutModel> BuscarSelecaoPorIdAsync(string nome)
            => await _dbContext.Selecao
                                .Where(x => x.Nome.ToLower() == nome.ToLower())
                                .Select(x => new CopaDoMundoOutPutModel
                                {
                                    Id = x.Id,
                                    Nome = x.Nome,
                                    TitulosMundiais = x.TitulosMundiais,
                                    Continente = x.Continente
                                })
                                .FirstOrDefaultAsync();


        public async Task<bool> CriarSelecaoAsync(CadastrarSelecaoInputModel model)
        {
            var context = _dbContext.Selecao;

            var selecaoExiste = context.Where(x => x.Nome.Contains(model.Nome)).FirstOrDefault();

            if (selecaoExiste is not null)
                return false;

            var id = context.Select(x => x.Id).Max() + 1;

            await context.AddAsync(new SelecaoEntity(id, model.Nome, model.TitulosMundiais, model.Continente));

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
