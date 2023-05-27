﻿using System.Text.Json.Serialization;

namespace SEP6.Models
{
    public class CrewMember
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("profile_path")]
        public string ProfilePath { get; set; }
    }
}
