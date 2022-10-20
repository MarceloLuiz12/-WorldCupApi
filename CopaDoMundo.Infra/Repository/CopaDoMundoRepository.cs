using CopaDoMundo.Domain.DTO_s.InputModels;
using CopaDoMundo.Domain.DTO_s.OutputModelAuxiliar;
using CopaDoMundo.Domain.DTO_s.OutputModels;
using CopaDoMundo.Domain.Entities;
using CopaDoMundo.Domain.Enums;
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

        public async Task<PaginadoOutputModel<SelecaoOutPutModel>> BuscarSelecaoAsync(BuscarSelecaoInputModel inputModel)
        {
            var pagina = inputModel.Pagina ?? 0;

            var query = _dbContext.Selecao.Where(x => x.Situacao == SituacaoEnum.Ativo);

            if (!string.IsNullOrWhiteSpace(inputModel.FiltroPorContinente))
                query = query.Where(x => x.Continente.ToLower().Contains(inputModel.FiltroPorContinente.ToLower()));

            var dados = await query.Select(x => new SelecaoOutPutModel
            {
                Id = x.Id,
                Nome = x.Nome,
                TitulosMundiais = x.TitulosMundiais,
                Continente = x.Continente,
                Situacao = x.Situacao
            })
            .OrderBy(x => x.Continente)
            .Skip(pagina)
            .Take(inputModel.ObterTotalItens())
            .ToListAsync();

            return new PaginadoOutputModel<SelecaoOutPutModel>
                (dados, query.Count(), inputModel.PaginaAtual(), inputModel.ObterTotalItens());
        }


        public async Task<SelecaoOutPutModel> BuscarSelecaoPorNomeAsync(string nome)
        {
            var query = _dbContext.Selecao.AsQueryable();

            if(!string.IsNullOrWhiteSpace(nome))
                query = query.Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            var dados = await query.ToListAsync();

            return dados.Select(x => new SelecaoOutPutModel
            {
                Id = x.Id,
                Nome = x.Nome,
                TitulosMundiais = x.TitulosMundiais,
                Continente = x.Continente
            }).FirstOrDefault();
        }

        public async Task<SelecaoEntity> CriarSelecaoAsync(CadastrarSelecaoInputModel model)
        {
            var context = _dbContext.Selecao;

            var selecaoExiste = context.Where(x => x.Nome.Contains(model.Nome)).FirstOrDefault();

            if (selecaoExiste is not null)
                return null;

            var id = context.Select(x => x.Id).Max() + 1;

            var result = new SelecaoEntity(id, model.Nome, model.TitulosMundiais, model.Continente, SituacaoEnum.Ativo);

            await context.AddAsync(result);

            return result;
        }

        public async Task<SelecaoEntity> AlterarSelecaoAsync(AlterarSelecaoInputModel inputModel)
        {
            var context = _dbContext.Selecao;

            var selecao = await context.Where(x => x.Id == inputModel.Id).FirstOrDefaultAsync();

            if (selecao is null)
                return null;

            selecao.AlterarCadastro(inputModel.Id, inputModel.Nome, 
                                    inputModel.TitulosMundiais,
                                             inputModel.Continente);

            return selecao;
        }

        public async Task<SelecaoEntity> AlterarSituacaoSelecao(long id)
        {
            var context = _dbContext.Selecao;

            var selecao =  await context.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (selecao is null)
                return null;

            selecao.AlterarSituacao();

            return selecao;
        }

    }
}
