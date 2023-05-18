namespace SEP6.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public string? Biography { get; set; }
        public string? Birthday { get; set; }
        public float Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public string? Character { get; set; }
        public bool Adult { get; set; }
        public string? PlaceOfBirth { get; set; }

    }
}
