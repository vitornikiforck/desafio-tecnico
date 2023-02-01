using Newtonsoft.Json;
using System.Text.Json.Serialization;

public partial class Program
{
    public record Result(
        [property: JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("page")] int? Page,
        [property: JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("per_page")] int? PerPage,
        [property: JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("total")] int? Total,
        [property: JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("total_pages")] int? TotalPages,
        [property: JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("data")] IReadOnlyList<ResultData> Data
    );
}