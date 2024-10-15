using Arner.DataAccess.Models;
using Arner.Service.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Arner.Service.Helper;

namespace Arner.Web.API
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
        [HttpGet("byname/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            
            if (!ValidateHelperClass.ValidateName(name))
            {
                return BadRequest("The username is not valid");
            }

            try
            {
                var foundUser = await _userRepository.GetUserByName(name);
                if (foundUser != null)
                {
                    return Ok(foundUser);
                }
                else
                {
                    return NotFound("The user is not found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            try
            {
                var foundUser = await _userRepository.GetUserByID(id);
                if (foundUser != null)
                {
                    return Ok(foundUser);
                }
                else
                {
                    return NotFound("The user is not found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var foundUser = await _userRepository.GetUserByName(user.Username);
                if (foundUser != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "The username is already existed");
                }
                else
                {
                    user.CreatedAt = TimeZoneClass.GetCurrentVietNameTime();
                    user.UpdatedAt = TimeZoneClass.GetCurrentVietNameTime();
                    var createdUser = await _userRepository.Add(user);
                    return CreatedAtAction(nameof(GetUserByID), new { id = createdUser.ID }, createdUser);
                }
            } catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data in database");
            }

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundUser = await _userRepository.GetUserByID(id);

            if (foundUser == null)
            {
                return NotFound("User is not found");
            } else 
            {
                if (foundUser.ID != user.ID || foundUser.Username != user.Username)
                {
                    return BadRequest("ID or Username is not match");
                }
                else
                {
                    try
                    {
                        user.UpdatedAt = TimeZoneClass.GetCurrentVietNameTime();

                        var result = await _userRepository.Update(user);
                        return Ok(result);
                    }
                    catch (Exception e) 
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data from database");
                    }
                }

            }
    
        }

        [HttpDelete("byname/{name}")]
        public async Task<ActionResult> DeleteUser(string name)
        {
            if (!ValidateHelperClass.ValidateName(name))
            {
                return BadRequest("The username is not valid");
            }

            try
            {
                var foundUser = await _userRepository.GetUserByName(name);
                if (foundUser != null)
                {
                    
                    return Ok(await _userRepository.Delete(foundUser));
                }

                return NotFound("User is not found");
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var foundUser = await _userRepository.GetUserByID(id);
                if (foundUser != null)
                {

                    return Ok(await _userRepository.Delete(foundUser));
                }

                return NotFound("User is not found");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting data in database");
            }

        }
    }

}
