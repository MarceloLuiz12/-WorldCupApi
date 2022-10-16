namespace CopaDoMundo.Domain.Entities
{
    public class SelecaoEntity
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public int TitulosMundiais { get; private set; }
        public string Continente { get; private set; }

        public SelecaoEntity(long id, string nome, int titulosMundiais, string continente)
        {
            Id = id;
            Nome = nome;
            TitulosMundiais = titulosMundiais;
            Continente = continente;
        }
    }
}
