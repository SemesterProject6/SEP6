using System.Text;
using System.Text.Json;
using SEP6.Models;

namespace SEP6.Data.FavoriteMovie
{
    public class FavoriteMovieService : IFavoriteMovieService
    {
        string url = "https://localhost:7178/FavoriteMovie";
        HttpClient client;

        public FavoriteMovieService()
        {
            client = new HttpClient();
        }

        public async Task AddFavoriteMovie(int userID, int movieID)
        {
            HttpContent content = new StringContent(
                "",
                Encoding.UTF8,
                "application/json"
                );
            await client.PostAsync(url + "/addFavorite?userID=" + userID + "&movieID=" + movieID, content);
        }

        public async Task<int> GetFavoriteMovieCount(int movieID)
        {
            string message = await client.GetStringAsync(url + "/getFavoriteMovieCount?movieID=" + movieID);
            int results = JsonSerializer.Deserialize<int>(message);
            return results;
        }

        public async Task<ListOfMovies> GetFavoriteMoviesByID(int userID)
        {
            string message = await client.GetStringAsync(url + "/getFavorites?userID=" + userID);
            ListOfMovies results = JsonSerializer.Deserialize<ListOfMovies>(message);
            return results;
        }

        public async Task<List<Movie>> GetFavoriteMoviesByUser(int userID)
        {
            string message = await client.GetStringAsync(url + "/getFavoritesByUser?userID=" + userID);
            List<Movie> results = JsonSerializer.Deserialize<List<Movie>>(message);
            return results;
        }

        public async Task<bool> GetIsFavoriteMovieByID(int userID, int movieID)
        {
            string message = await client.GetStringAsync(url + "/getFavorite?userID=" + userID + "&movieID=" + movieID);
            bool result = JsonSerializer.Deserialize<bool>(message);
            return result;
        }
        
        public async Task<ListOfMovies> GetFavoriteMoviesByEmail(string email)
        {
            string message = await client.GetStringAsync(url + "/getFavoritesByEmail?email=" + email);

            try
            {
                ListOfMovies result = JsonSerializer.Deserialize<ListOfMovies>(message);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task RemoveFavoriteMovieByID(int userID, int movieID)
        {
            await client.DeleteAsync(url + "/removeFavorite?userID=" + userID + "&movieID=" + movieID);
        }
    }
}
