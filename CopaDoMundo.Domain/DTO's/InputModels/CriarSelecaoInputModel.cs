namespace CopaDoMundo.Domain.DTO_s.InputModels
{
    public class CadastrarSelecaoInputModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int TitulosMundiais { get; set; }
        public string Continente { get; set; }
    }
}
