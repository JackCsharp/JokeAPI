using JokeAPI.Services.GuildService;
using JokeAPI.Services.JokeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class GuildController : ControllerBase
    {
        private readonly IGuildService _guildService;

        public GuildController(IGuildService guildService)
        {
            _guildService = guildService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Guild>>> GetAllGuild()
        {
            return await _guildService.GetAllGuild();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Guild>>> GetGuild(int id)
        {
            var result = await _guildService.GetGuild(id);
            if (result is null)  return NotFound("Wrong id!");
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Guild>> AddGuild(Guild guild)
        {
            return await _guildService.AddGuild(guild);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Guild>>> UpdateGuild(int id, Guild guild)
        {
            var result = await (_guildService.UpdateGuild(id, guild));
            if (result is null) return NotFound("Wrong id!");
            return result;

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Guild>>> DeleteGuild(int id)
        {
            var result = await (_guildService.DeleteGuild(id));
            if (result is null) return NotFound("Wrong id!");
            return result;
        }
        [HttpGet("AllMembers/{id}")]
        public async Task<ActionResult<List<User>>> GetAllMembers(int id)
        {
            var users = await _guildService.GetAllMembers(id);
            if (users is null) return NotFound("users");
            return users;
        }
    }
}