using JokeAPI.Model;
using Microsoft.Identity.Client;

namespace JokeAPI.Services.JokeService
{
    public class JokeService : IJokeService
    {
        List<Joke> allJokes = new List<Joke>{
            };
        private readonly DataContext _context;
        public JokeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Joke>> GetJokesByGuild(int guildId)
        {
            var jokes = await (from joke in _context.Jokes
                               join user in _context.Users on joke.UserId equals user.UserId
                               join guild in _context.Guilds on user.GuildId equals guild.GuildId
                               where guild.GuildId == guildId
                               select joke).ToListAsync();
            return jokes;
        }

        public async Task<List<Joke>> AddJoke(Joke joke)
        {
            _context.Jokes.Add(joke);
            await _context.SaveChangesAsync();
            return allJokes;
        }

        public async Task<List<Joke>?> DeleteJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);
            if (joke is null) return null;
            joke.Title = "Joke was deleted";
            joke.Text = "Joke was deleted";
            await _context.SaveChangesAsync();

            return allJokes;
        }

        public async Task<List<Joke>> GetAllJokes()
        {
            var jokes = await _context.Jokes.ToListAsync();
            return jokes;
        }

        public async Task<List<Joke>?> GetJoke(int id)
        {
            var joke = await _context.Jokes.FindAsync(id);
            if (joke is null) return null;
            allJokes.Add(joke);
            return (allJokes);
        }

        public async Task<List<Joke>?> UpdateJoke(int id, Joke request)
        {
            var joke = await _context.Jokes.FindAsync(id);

            if (joke is null) return null;

            joke.Title = request.Title;
            joke.Text = request.Text;

            await _context.SaveChangesAsync();

            return allJokes;
        }
        public async Task<bool> Like(int userId, int jokeId)
        {
            var joke = await _context.Jokes.FindAsync(jokeId);
            if (joke is null) return false;

            var raters = joke.RatersId;
            joke.RatersId = raters+$"{userId},";

            joke.Rating++;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<User>?> GetAllLikers(int jokeId)
        {
            var joke = await _context.Jokes.FindAsync(jokeId);
            if (joke == null) return null;
            string[] likersId = joke.RatersId.Split(',');
            List<User> likers = new List<User>();

            foreach (string likerId in likersId)
            {
                if (int.TryParse(likerId, out int userId))
                {
                    var user = await _context.Users.FindAsync(userId);
                    if (user != null)
                    {
                        likers.Add(user);
                    }
                }
            }

            return likers;
        }
        public async Task<List<Comment>> GetAllComments(int jokeId)
        {
            var comments = await _context.Comments.Where(c => c.JokeId == jokeId).ToListAsync();
            return comments;
        }
    }
}
