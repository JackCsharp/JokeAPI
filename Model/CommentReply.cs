using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class CommentReply
    {
        public int CommentReplyId { get; set; }
        public string Text { get; set;} = string.Empty;
        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
