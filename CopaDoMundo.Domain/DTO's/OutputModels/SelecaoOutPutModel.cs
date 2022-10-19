using CopaDoMundo.Domain.Enums;

namespace CopaDoMundo.Domain.DTO_s.OutputModels
{
    public class SelecaoOutPutModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int TitulosMundiais { get; set; }
        public string Continente { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
