using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = string.Empty;
        [ForeignKey("Joke")]
        public int JokeId { get; set; }
        [ForeignKey("User")]
        public int UserId{ get; set; }

    }
}
