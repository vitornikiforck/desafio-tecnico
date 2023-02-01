using Newtonsoft.Json;
using System.Text.Json.Serialization;

public partial class Program
{
    public record ResultData(
        [property: JsonProperty("competition", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("competition")] string Competition,
        [property: JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("year")] int? Year,
        [property: JsonProperty("round", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("round")] string Round,
        [property: JsonProperty("team1", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("team1")] string Team1,
        [property: JsonProperty("team2", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("team2")] string Team2,
        [property: JsonProperty("team1goals", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("team1goals")] string Team1goals,
        [property: JsonProperty("team2goals", NullValueHandling = NullValueHandling.Ignore)]
        [property: JsonPropertyName("team2goals")] string Team2goals
    );
}