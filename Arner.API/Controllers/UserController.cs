using Arner.DataAccess.Models;
using Arner.Helper.Exceptions;
using Arner.Service.Helper;
using Arner.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Arner.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                var tempUser = await _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = tempUser.ID }, tempUser);
            }
            catch (DuplicateDataException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while inserting data");
            }

        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserByname(string name)
        {
            try
            {
                var tempUser = await _userService.GetUserByName(name);

                if (tempUser == null)
                {
                    return NotFound("The requested resource is not existed");
                }

                return Ok(tempUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting data");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            { 
                var tempUser = await _userService.GetUserById(id);
   
                if (tempUser == null)
                {
                    return NotFound("The requested resource is not existed");
                }

                return Ok(tempUser);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting data");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                var tempUser = await _userService.UpdateUser(id, user);
                return Ok(tempUser);
            }
            catch (NotMatchException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating data");
            }
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var tempUser = await _userService.DeleteUser(id);
                return Ok(tempUser);
            }
            catch (NotFoundException)
            {
                return NotFound("The requested resource is not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting data");
            }
        }
    }

}
