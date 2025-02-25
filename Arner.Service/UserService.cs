using Arner.DataAccess.Models;
using Arner.Helper.Exceptions;
using Arner.Service.IRepository;
using Arner.Service.IService;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.Design;

namespace Arner.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> AddUser(User user)
        {
            var tempUser = await _userRepo.GetUserByID(user.ID);
            if (tempUser != null)
                throw new DuplicateDataException("The username is already existed");
            else
                return await _userRepo.Add(user);
            
        }

        public async Task<User?> GetUserByName(string name)
        {
            return await _userRepo.GetUserByName(name);
        }

        public async Task<User?> GetUserById(int id) 
        {
            return await _userRepo.GetUserByID(id);
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            if (id != user.ID)
            {
                throw new NotMatchException();
            }
            return await _userRepo.Update(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            var tempUser = await _userRepo.GetUserByID(id);
            if (tempUser != null)
                throw new NotFoundException();
            else
                return await _userRepo.Delete(tempUser);
        }

        public async Task<IEnumerable<User>> GetAll() => await _userRepo.GetAll(); 
    }
}
