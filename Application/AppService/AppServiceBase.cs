using System.Text.Json;

namespace ApplicationBlog.AppService
{
    /// <summary>
    /// Classe Base de Serviços
    /// </summary>
    public abstract class AppServiceBase
    {
        public JsonSerializerOptions _serializerOptions;

        public AppServiceBase()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }
    }
}
