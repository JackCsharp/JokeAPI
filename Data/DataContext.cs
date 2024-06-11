using Microsoft.EntityFrameworkCore;

namespace JokeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=jokedb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Joke> Jokes{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentsReplies { get; set; }
        public DbSet<GuildChatMessage> GuildChatMessages { get; set; }
        public DbSet<Like> Likes { get; set; }

    }
}
