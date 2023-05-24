using SEP6.Models;

namespace SEP6.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id);
        void SetActorId(int id);
        int GetActorId();
        Task<CreditsForMovies> GetMovieCreditsByActorId(int actorId);
        Task<ListOfActors> GetPopularActors(int page);
        Task<ListOfActors> GetActorsBySearch(int page, string query);
    }
}
