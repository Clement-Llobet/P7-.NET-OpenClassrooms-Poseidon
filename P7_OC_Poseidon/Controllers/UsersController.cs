﻿using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7_OC_Poseidon.Models;
using P7_OC_Poseidon.Models.Dtos;
using P7_OC_Poseidon.Models.Services.UserService;

namespace P7_OC_Poseidon.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await _userService.GetAllUsers();
            if (result == null)
                return NotFound("Users not found");

            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _userService.GetSingleUser(id);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var result = await _userService.UpdateUser(id, userDto);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

        // POST: api/Users/Register
        [HttpPost("Register"), AllowAnonymous]
        public async Task<ActionResult<User>> Register(UserDto userDto)
        {
            var result = await _userService.RegisterUser(userDto);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

        // POST: api/Users/Register
        [HttpPost("Login"), AllowAnonymous]
        public async Task<ActionResult<User>> Login(AuthDto userDto)
        {
            var result = await _userService.LoginUser(userDto);

            if (result == null)
            {
                return BadRequest("Account or password doesn't match");
            }

            return Ok(result);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }
    }
}
