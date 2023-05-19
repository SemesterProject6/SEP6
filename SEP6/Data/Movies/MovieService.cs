using SEP6.Models;
using System.Text.Json;

namespace SEP6.Data.Movies
{
    public class MovieService : IMovieService
    {

        string url = "https://localhost:7178/movie";

        HttpClient client;
        private int movieId = 0;

        public MovieService()
        {
            client = new HttpClient();
        }

        public async Task<Movie> GetMovieByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Movie result = JsonSerializer.Deserialize<Movie>(message);
            return result;
        }

        public int GetMovieId()
        {
            return movieId;
        }

        public void SetMovieId(int id)
        {
            movieId = id;
        }
        public async Task<ListOfMovies> GetMoviesBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public Task<ListOfMovies> GetMoviesByRating(int page)
        {
            throw new NotImplementedException();
        }

        public Task<ListOfMovies> GetMoviesByTitle(int page)
        {
            throw new NotImplementedException();
        }
    }
}
