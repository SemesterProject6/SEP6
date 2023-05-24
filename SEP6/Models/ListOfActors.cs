using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class ListOfActors
    {
        [JsonPropertyName("page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("results")]
        public List<Actor>? Actors { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPage { get; set; }
    }
}
