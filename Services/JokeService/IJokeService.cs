namespace JokeAPI.Services.JokeService
{
    public interface IJokeService
    {
        Task<List<Joke>> GetAllJokes();
        Task<List<Joke>?> GetJoke(int id);
        Task<List<Joke>> AddJoke(Joke joke);
        Task<List<Joke>?> DeleteJoke(int id);
        Task<List<Joke>?> UpdateJoke(int id, Joke request);
        Task<bool> Like(int userId, int jokeId);
        Task<List<User>?> GetAllLikers(int jokeId);
        Task<List<Comment>> GetAllComments(int jokeId);
    }
}
