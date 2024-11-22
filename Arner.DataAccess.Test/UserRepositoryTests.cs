using Arner.DataAccess.Models;
using Arner.Helper.Exceptions;
using Arner.Service;
using Arner.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Arner.DataAccess.Test
{
    [TestClass]
    public class UserRepositoryTests
    {

        private ArnerDbContext _context;
        private IUserRepository _sut;
        
        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ArnerDbContext>()
                          .UseInMemoryDatabase(databaseName: $"TestDatabase_{Guid.NewGuid()}")
                          .Options;
            _context = new ArnerDbContext(options);
            _context.Add(new User() {ID = 1, Username = "john_doe", PhoneNumber = "0123456789", Password = "password123", Email = "john.doe@example.com" });
            _context.Add(new User() {ID = 2, Username = "jane_smith", PhoneNumber = "0987654321", Password = "securePass456", Email = "jane.smith@example.com" });
            _context.SaveChanges();
            _sut = new UserRepository(_context);
        }


        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task Add_WhenUserIsValid_UserIsAddedSuccessfully()
        {
            //Arrange 
            User testUser = new User { Username = "eren", PhoneNumber = "0123456789", Password = "1234", Email = "eren@gmail.com" };

            //Act
            await _sut.Add(testUser);
            var result = await _context.Users.FirstOrDefaultAsync(x => x.ID == testUser.ID);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testUser.ID, result.ID);
            Assert.AreEqual(testUser.Username, result.Username);
        }


        [TestMethod]
        public async Task GetUserById_WhenUserExists_ReturnUser()
        {
            //Arrange
            int userId = 1;

            //Act
            var result = await _sut.GetUserByID(userId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.ID);
        }

        [TestMethod]
        public async Task GetUserById_WhenUserDoesNotExist_ReturnNull()
        {
            //Arrange
            int userId = 0;

            //Act
            var result = await _sut.GetUserByID(userId);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetUserByName_WhenUserExists_ReturnUser()
        {
            //Arrange
            string userName = "john_doe";

            //Act
            var result = await _sut.GetUserByName(userName);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userName, result.Username);
        }
        [TestMethod]
        public async Task GetUserByName_WhenUserDoesNotExist_ReturnNull()
        {
            //Arrange
            string userName = "steve";

            //Act
            var result = await _sut.GetUserByName(userName);

            //Assert
            Assert.IsNull(result);
        }
    }
}