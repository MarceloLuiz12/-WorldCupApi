using System.Text.Json.Serialization;

namespace CopaDoMundo.Domain.DTO_s.ResponseModel
{
    public class BancoRequestModel
    {
        [JsonPropertyName("ispb")]
        public string Ispb { get; set; }

        [JsonPropertyName("name")]
        public string NomeAbreviado { get; set; }

        [JsonPropertyName("code")]
        public int Codigo { get; set; }

        [JsonPropertyName("fullname")]
        public string NomeCompleto { get; set; }
    }
}
