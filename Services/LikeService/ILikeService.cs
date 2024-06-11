namespace JokeAPI.Services.LikeService
{
    public interface ILikeService
    {
        public Task<Like> AddLike(Like like);
        public Task<Like> DeleteLike(int id);
        public Task<List<Like>> GetLikesByUser(int userId);
        
    }
}
