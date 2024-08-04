using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBTBGlobal_PruebaTecnicaAPI.Interfaces;
using TBTBGlobal_PruebaTecnicaAPI.Models;

namespace TBTBGlobal_PruebaTecnicaAPI.Controllers
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

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<User> users = await _userService.GeUsersAsync();
                return StatusCode(StatusCodes.Status200OK, new
                {
                    message = "ok",
                    res = users
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("getById/{userId}")]
        public async Task<IActionResult> getById(Int32 userId)
        {
            try
            {
                User user = await _userService.GeUsersByIdAsync(userId);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    message = "ok",
                    res = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error",
                    details = ex.Message
                });
            }
        }


        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> insert([FromBody] User user)
        {
            try
            {
                Boolean result = await _userService.InsertUser(user);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "Usuario insertado correctamente"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Error"
                    });
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error",
                    details = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> update([FromBody] User user)
        {
            try
            {
                Boolean result = await _userService.UpdateUser(user);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "Usuario editado correctamente"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Error"
                    });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error",
                    details = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("delete/{userId}")]
        public async Task<IActionResult> delete(Int32 userId)
        {
            try
            {
                Boolean result = await _userService.DeleteUser(userId);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        message = "Usuario eliminado correctamente"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Error"
                    });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Error",
                    details = ex.Message
                });
            }
        }
    }
}
