using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EMS.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString;
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode;
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
            return services;
        }
    }
}
