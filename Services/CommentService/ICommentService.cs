namespace JokeAPI.Services.CommentService
{
    public interface ICommentService
    {
        Task<Comment> GetComment(int id);
        Task<List<Comment>> GetCommentsByJoke(int jokeId);
        Task<bool> DeleteComment(int id);
        Task<bool> AddComment(Comment comment);
        Task<bool> UpdateComment(Comment request,int id);
        Task<List<CommentReply>> GetAllReplies(int id);
    }
}
