using SEP6.Models;
using System.Text.Json;

namespace SEP6.Data.Actors
{
    public class ActorService : IActorService
    {
#if DEBUG
        string url = "https://localhost:7178/actor";
#else
       
        string url = "https://moviesep6api.azurewebsites.net/actor";
#endif
        HttpClient client;
        private int actorId = 0;

        public ActorService()
        {
            client = new HttpClient();
        }

        public async Task<Actor> GetActorByID(int id)
        {
            string message = await client.GetStringAsync(url + "/" + id);
            Actor result = JsonSerializer.Deserialize<Actor>(message);
            return result;
        }

        public int GetActorId()
        {
            return actorId;
        }

        public async Task<ListOfActors> GetActorsBySearch(int page, string query)
        {
            string message = await client.GetStringAsync(url + "/search?page=" + page + "&query=" + query);
            ListOfActors results = JsonSerializer.Deserialize<ListOfActors>(message);
            return results;
        }

        public async Task<CreditsForMovies> GetMovieCreditsByActorId(int actorId)
        {
            string message = await client.GetStringAsync(url + "/" + actorId + "/movie_credits");
            CreditsForMovies result = JsonSerializer.Deserialize<CreditsForMovies>(message);
            return result;
        }

        public async Task<ListOfActors> GetPopularActors(int page)
        {
            string message = await client.GetStringAsync(url + "/" + "popularActors?page=" + page);
            ListOfActors result = JsonSerializer.Deserialize<ListOfActors>(message);
            return result;
        }

        public void SetActorId(int id)
        {
            actorId = id;
        }
    }
}
