using Newtonsoft.Json;
using System.Text.Json.Serialization;

public partial class Program
{
    public record ResultPages(
        [property: JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("total_pages")] int? TotalPages);
}