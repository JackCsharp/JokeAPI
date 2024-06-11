using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class Like
    {
        public int LikeId { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Joke")]
        public int Id { get; set; }
    }
}
