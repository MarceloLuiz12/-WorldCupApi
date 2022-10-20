using CopaDoMundo.Domain.DTO_s.InputModelAuxiliar;

namespace CopaDoMundo.Domain.DTO_s.InputModels
{
    public class BuscarSelecaoInputModel : BaseFilterInputModel
    {
        public string FiltroPorContinente { get; set; }
    }
}
