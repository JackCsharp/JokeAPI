using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class Joke
    {
        public int Id { get; set; }
        public string Title { get; set; } = ("");
        public string Text { get; set; } = ("");
        public int Rating { get; set; }
        public string RatersId { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
