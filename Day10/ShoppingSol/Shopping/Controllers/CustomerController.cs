using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Interfaces;
using Shopping.Models.DTOs;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Login(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    message = "invalid credentials";
                }
            }
            catch (Exception ex)
            {
                message = "error occured during login";
            }
            return BadRequest(message);
        }
    }
}