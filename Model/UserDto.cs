using System.ComponentModel.DataAnnotations.Schema;

namespace JokeAPI.Model
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
