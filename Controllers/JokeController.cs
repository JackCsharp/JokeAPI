using JokeAPI.Model;
using JokeAPI.Services.JokeService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class JokeController : ControllerBase
    {
        private readonly IJokeService _jokeService;

       
        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Joke>>> GetAllJokes()
        {
            return await _jokeService.GetAllJokes();
        }
         
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetJoke(int id)
        {
            var result = await _jokeService.GetJoke(id);
            if (result is null) return NotFound("Wrong id!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Joke>>> AddJoke(Joke joke)
        {
            var result = await _jokeService.AddJoke(joke);
            if (result is null) return NotFound("Wrong id!");
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Joke>>> UpdateJoke(int id,Joke request)
        {
            var result = await _jokeService.UpdateJoke(id, request);
            if (result is null) return NotFound("Wrong id!");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Joke>>> DeleteJoke(int id)
        {
            var result = await _jokeService.DeleteJoke(id);
            if (result is null) return NotFound("Wrong id!");
            return Ok(result);
        }
        [HttpPost("Like")]
        public async Task<ActionResult> Like(int userId, int jokeId)
        {
            if (await _jokeService.Like(userId, jokeId)) return Ok("Success");
            return BadRequest("Wrong id!");
        }
        [HttpGet("AllLikers")]
        public async Task<ActionResult<List<User>>> GetAllLikers(int userId)
        {
            var users =  await _jokeService.GetAllLikers(userId);
            if (users == null) return NotFound("Wrong id!");
            return Ok(users);
        }
        [HttpGet("Comments/{id}")]
        public async Task<ActionResult<List<Comment>>> GetAllComments(int id)
        {
            var comments = await _jokeService.GetAllComments(id);
            return Ok(comments);
        }
    }
}
