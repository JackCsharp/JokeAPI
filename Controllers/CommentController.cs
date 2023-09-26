using JokeAPI.Services.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;


        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Joke>> GetComment(int id)
        {
            var result = await _commentService.GetComment(id);
            if (result is null) return NotFound("Wrong id!");
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetCommentsByJoke(int jokeId)
        {
            var comments = await _commentService.GetCommentsByJoke(jokeId);
            if (comments is null) return NotFound("Wrong id!");
            return Ok(comments);
        }
        [HttpPost]
        public async Task<ActionResult> AddComment(Comment comment)
        {
            var result = await _commentService.AddComment(comment);
            if (!result) return NotFound("Wrong id!");
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, Comment request)
        {
            var result = await _commentService.UpdateComment( request, id);
            if (!result) return NotFound("Wrong id!");
            return Ok("Succsess");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteComment(id);
            if (!result) return NotFound("Wrong id!");
            return Ok("Success");
        }
    }
}
