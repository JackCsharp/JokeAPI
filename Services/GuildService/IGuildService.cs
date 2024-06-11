namespace JokeAPI.Services.GuildService
{
    public interface IGuildService
    {
        Task<List<Guild>> GetAllGuild();
        Task<List<Guild>?> GetGuild(int id);
        Task<Guild> AddGuild(Guild guild);
        Task<List<Guild>?> UpdateGuild(int id, Guild guild);
        Task<List<Guild>?> DeleteGuild(int id);
        Task<List<User>?> GetAllMembers(int id);
        Task<GuildChatMessage> AddChatMessage(GuildChatMessage message);
        Task<List<GuildChatMessage>> GetAllChatMessagesByGuild(int guildId);

    }
}
