using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class CreditsForMovies
    {
        [JsonPropertyName("id")]
        public int ActorId { get; set; }

        [JsonPropertyName("cast")]
        public List<Movie> Movies { get; set; }
    }
}
