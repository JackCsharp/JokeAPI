using Microsoft.AspNetCore.Http.HttpResults;

namespace JokeAPI.Services.GuildService
{
    public class GuildService : IGuildService
    {
        private readonly DataContext _context;
        List<Guild> allGuilds = new List<Guild> { };
        public GuildService(DataContext context)
        {
            _context = context;
        }

        public async Task<Guild> AddGuild(Guild guild)
        {
            _context.Guilds.Add(guild);
            await _context.SaveChangesAsync();
            return guild;
        }

        public async Task<List<Guild>?> DeleteGuild(int id)
        {
            var guild = _context.Guilds.FirstOrDefault(x => x.GuildId == id);
            if (guild == null) return null;


            _context.Guilds.Remove(guild);
            await _context.SaveChangesAsync();
            return allGuilds;
        }

        public async Task<List<Guild>> GetAllGuild()
        {
            return await _context.Guilds.ToListAsync();
        }

        public async Task<List<User>?> GetAllMembers(int guildId)
        {
            return await _context.Users.Where(user => user.GuildId == guildId).ToListAsync();
        }

        public async Task<List<Guild>?> GetGuild(int id)
        {
            var guild = await _context.Guilds.FindAsync(id);
            if (guild == null) return null;
            allGuilds.Add(guild);
            return allGuilds;
        }

        public async Task<List<Guild>?> UpdateGuild(int id, Guild request)
        {
            var guild = await _context.Guilds.FindAsync(id);
            if (guild == null) return null;
            guild.Picture = request.Picture;
            guild.Name = request.Name;
            guild.Description = request.Description;   
            await _context.SaveChangesAsync();

            allGuilds.Add(guild);
            return allGuilds;
        }

    }
}
