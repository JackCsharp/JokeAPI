using JokeAPI.Services.CommentReplyService;
using JokeAPI.Services.CommentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentReplyController : ControllerBase
    {
        private readonly ICommentReplyService _commentReplyService;


        public CommentReplyController(ICommentReplyService commentReplyService)
        {
            _commentReplyService = commentReplyService;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Joke>> GetCommentReply(int id)
        //{
        //    var result = await _commentReplyService.GetCommentReply(id);
        //    if (result is null) return NotFound("Wrong id!");
        //    return Ok(result);
        //}
        [HttpGet("{commentId}")]
        public async Task<ActionResult<List<Comment>>> GetRepliesByComment(int commentId)
        {
            var comments = await _commentReplyService.GetAllByComment(commentId);
            if (comments is null) return NotFound("Wrong id!");
            return Ok(comments);
        }
        [HttpPost]
        public async Task<ActionResult> AddReply(CommentReply reply)
        {
            var result = await _commentReplyService.AddCommentReply(reply);
            if (!result) return NotFound("Wrong id!");
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReply(int id, CommentReply request)
        {
            var result = await _commentReplyService.UpdateCommentReply(request, id);
            if (!result) return NotFound("Wrong id!");
            return Ok("Succsess");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReply(int id)
        {
            var result = await _commentReplyService.DeleteCommentReply(id);
            if (!result) return NotFound("Wrong id!");
            return Ok("Success");
        }
    }
}
