using SEP6.Models;
using System.Text.Json;

namespace SEP6.Data.Actors
{
    public class ActorService : IActorService
    {
        string url = "https://localhost:7178/actor";
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

        public void SetActorId(int id)
        {
            actorId = id;
        }
    }
}
