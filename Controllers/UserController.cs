using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using JokeAPI.Services.UserService;

namespace JokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            if ( await _service.Register(request)) return Ok("Success");
            return BadRequest("Wrong data");
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            var response = await _service.Login(request);
            if (response!=null) return Ok(response.UserId);
            return BadRequest("Wrong data");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _service.GetUser(id);
            if (result == null) return BadRequest("Wrong id");
            return Ok(result);
        }
        [HttpDelete("{id}")]    
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (await _service.DeleteUser(id)) return Ok("Success");
            return BadRequest("Wrong id");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, UserDto request)
        {
            if (await _service.UpdateUser(id, request)) return Ok("Success");
            return BadRequest("Wrong id");
        }
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _service.GetAllUsers());
        }
        [HttpPut("UpdateGuild{userid},{guildid}")]
        public async Task<ActionResult<Guild>> UpdateUserGuild(int userid, int guildid)
        {
            var guild = await _service.UpdateUserGuild(userid, guildid);
            if (guild == null) return BadRequest("Wrong id");
            return Ok(guild);
        }
        [HttpGet("getjokes{userid}")]
        public async Task<ActionResult<Joke>> GetAllJokes(int userid)
        {
            var jokes = await _service.GetAllJokes(userid);
            if (jokes == null) return BadRequest("Wrong id");
            return Ok(jokes);
        }

    }
}
