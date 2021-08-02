using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using MovieRater.Helpers;
using System.Text;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using MovieRater.Data;
using MovieRater.Models;
using MovieRater.Services;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace MovieRaterWebAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class UsersController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [System.Web.Mvc.Authorize]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
