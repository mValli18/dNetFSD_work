﻿using HotelApp.Interfaces;
using HotelApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Controllers
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
        public ActionResult Register(UserDTO userDTO)
        {
            string message = "";
            try
            {
                var user = _userService.Register(userDTO);
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