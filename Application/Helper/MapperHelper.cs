using System.Text.Json;

namespace ApplicationBlog.Helper
{
    /// <summary>
    /// Classe Helper Genérica para mapeamento de dados entre Entidades
    /// </summary>
    /// <typeparam name="S">Tipo da Entidade de Entrada (Souce)</typeparam>
    /// <typeparam name="D">Tipo da Entidade de Saída (Destination)</typeparam>
    public class MapperHelper<S, D>
    {
        public D? Map(S source)
        {
            var _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var jSonSource = JsonSerializer.Serialize(source, _serializerOptions);
            var destination = JsonSerializer.Deserialize<D>(jSonSource, _serializerOptions);

            return destination;
        }
    }
}
