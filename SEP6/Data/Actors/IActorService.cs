using SEP6.Models;

namespace SEP6.Data.Actors
{
    public interface IActorService
    {
        Task<Actor> GetActorByID(int id);
        void SetActorId(int id);
        int GetActorId();
    }
}
