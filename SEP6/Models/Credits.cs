using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class Credits
    {
        [JsonPropertyName("id")]
        public int MovieId { get; set; }

        [JsonPropertyName("cast")]
        public List<Actor> Actors { get; set; }
    }
}
