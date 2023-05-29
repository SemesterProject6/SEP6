using System.Text;
using System.Text.Json;
using SEP6.Models;

namespace SEP6.Data.Users
{
    public class UserService : IUserService
    {
#if DEBUG
        string url = "https://localhost:7178/user";
#else
       
        string url = "https://moviesep6api.azurewebsites.net/user";
#endif
        private int userId;
        HttpClient client;

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string email, string password)
        {
            string message = await client.GetStringAsync($"{url}/validate?email={email}&password={password}");
            try
            {
                User result = JsonSerializer.Deserialize<User>(message);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public async Task<User> GetUserByID(int id)
        {
            string message = await client.GetStringAsync($"{url}/get?id={id}");
            try
            {
                User result = JsonSerializer.Deserialize<User>(message);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public async Task CreateAccount(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PostAsync($"{url}/createAccount", content);
        }

        public async Task UpdateAccount(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);

            HttpContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "application/json"
                );

            await client.PutAsync($"{url}/updateAccount", content);
        }

        public void SetUserId(int id)
        {
            userId = id;
        }

        public int GetUserId()
        {
            return userId;
        }

    }
}
