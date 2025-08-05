using Arner.DataAccess.Models;

namespace Arner.Service.IService
{
    public interface IUserService : IService<User>
    {
        Task<User?> GetUserByName(string name);
        Task<User?> GetUserById(int id); 
    }
}
