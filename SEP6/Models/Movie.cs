using System.Text.Json;
using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class Movie
    {
        [JsonPropertyName("original_title")]
        public string Original_Title { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("genres")]
        public List<Genre> Genre { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get;set; }
        [JsonPropertyName("poster_path")]
        public string PosterRoute { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("vote_average")]
        public float? Rating { get; set; }
        [JsonPropertyName("vote_count")]
        public int? NrOfVotes { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
