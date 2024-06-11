
namespace JokeAPI.Services.LikeService
{
    public class LikeService : ILikeService
    {
        private readonly DataContext _context;
        public LikeService(DataContext context) 
        {  
            _context = context; 
        }
        public async Task<Like> AddLike(Like like)
        {
            await _context.Likes.AddAsync(like);
            return like;
        }

        public async Task<Like> DeleteLike(int id)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.Id == id);
            if (like == null) return null;
            return like;
        }

        public Task<List<Like>> GetLikesByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
