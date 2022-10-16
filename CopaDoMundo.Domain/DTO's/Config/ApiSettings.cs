namespace CopaDoMundo.Domain.DTO_s
{
    public class ApiSettings
    {
        public string ApiKey { get; set; }

        public ApiSettings() { }
        public ApiSettings(string apiKey)
            => ApiKey = apiKey;
    }
}
