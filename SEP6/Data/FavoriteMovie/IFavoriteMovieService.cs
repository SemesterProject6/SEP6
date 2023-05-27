using SEP6.Models;

namespace SEP6.Data.FavoriteMovie
{
    public interface IFavoriteMovieService
    {
        Task AddFavoriteMovie(int userID, int movieID);
        Task<ListOfMovies> GetFavoriteMoviesByID(int userID);
        Task<List<Movie>> GetFavoriteMoviesByUser(int userID);
        Task<bool> GetIsFavoriteMovieByID(int userID, int movieID);
        Task<ListOfMovies> GetFavoriteMoviesByEmail(string email);
        Task RemoveFavoriteMovieByID(int userID, int movieID);
        Task<int> GetFavoriteMovieCount(int movieID);
    }
}
