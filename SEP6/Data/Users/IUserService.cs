using SEP6.Models;

namespace SEP6.Data.Users
{
    public interface IUserService
    {
        Task<User> ValidateUser(string email, string password);
        Task<User> GetUserByID(int id);
        Task CreateAccount(User user);
        Task UpdateAccount(User user);
        void SetUserId(int id);
        int GetUserId();
    }
}
