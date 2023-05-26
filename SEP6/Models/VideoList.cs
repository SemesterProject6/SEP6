using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class VideoList
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("results")]
        public List<Video> videos { get; set; }
    }
}
