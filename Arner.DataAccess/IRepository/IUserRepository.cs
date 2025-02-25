using Arner.DataAccess.IRepository;
using Arner.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByName(string name);
 
        Task<User?> GetUserByID(int id);
        
    }
}
