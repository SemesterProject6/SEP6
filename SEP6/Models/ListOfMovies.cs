namespace SEP6.Models
{
    public class ListOfMovies
    {
        public int CurrentPage { get; set; }

        public List<Movie> movies { get; set; }

        public int TotalPage { get; set; }
    }
}
