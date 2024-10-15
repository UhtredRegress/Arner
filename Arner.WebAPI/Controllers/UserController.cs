using Arner.DataAccess.Models;
using Arner.Service;
using Arner.Service.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace Arner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            var createdUser = _userRepository.AddUser(user);
            return CreatedAtAction(nameof(CreateUser), createdUser);
        }
    }
}
