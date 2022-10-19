using CopaDoMundo.Domain.Enums;

namespace CopaDoMundo.Domain.Entities
{
    public class SelecaoEntity
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public int TitulosMundiais { get; private set; }
        public string Continente { get; private set; }
        public SituacaoEnum Situacao { get; private set; }
        public SelecaoEntity(long id, string nome, int titulosMundiais, string continente, SituacaoEnum situacao)
        {
            Id = id;
            Nome = nome;
            TitulosMundiais = titulosMundiais;
            Continente = continente;
            Situacao = situacao;
        }

        public SelecaoEntity AlterarCadastro(long id, string nome, int titulosMundiais, string continente)
        {
            Id = id;
            Nome = nome;
            TitulosMundiais = titulosMundiais;
            Continente = continente;

            return this;
        }

        public void AlterarSituacao()
        {
            Situacao = Situacao == SituacaoEnum.Ativo ? SituacaoEnum.Inativo : SituacaoEnum.Ativo;
        }
    }
}
