using SEP6.Models;

namespace SEP6.Data.Movies
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByID(int id);

        Task<ListOfMovies> GetMoviesByRating(int page);

        Task<ListOfMovies> GetMoviesByTitle(int page);

        void SetMovieId(int id);
        int GetMovieId();
        Task<ListOfMovies> GetMoviesBySearch(int page, string query);
    }
}
