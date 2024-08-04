using TBTBGlobal_PruebaTecnicaAPI.Models;

namespace TBTBGlobal_PruebaTecnicaAPI.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GeUsersAsync();
        Task<User> GeUsersByIdAsync(Int32 id);
        Task<Boolean> InsertUser(User user);
        Task<Boolean> UpdateUser(User user);
        Task<Boolean> DeleteUser(Int32 userId);
    }
}
