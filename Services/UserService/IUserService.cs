namespace JokeAPI.Services.UserService
{
    public interface IUserService
    {
        Task<User?> Login(UserDto request);
        Task<bool> Register(UserDto request);
        Task<List<User>?> GetUser(int id);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdateUser(int id, UserDto request);
        Task<List<User>> GetAllUsers();
        Task<Guild> UpdateUserGuild(int userid, int guildid);
        Task<List<Joke>?> GetAllJokes(int userid);
        

    }
}
