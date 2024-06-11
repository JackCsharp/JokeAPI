using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class GuildChatMessage
    {
        public int GuildChatMessageId { get; set; }
        public string Text { get; set; } = ("");
        

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Guild")]
        public int GuildId { get; set; }
    }
}
