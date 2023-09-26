namespace JokeAPI.Services.CommentReplyService
{
    public interface ICommentReplyService
    {
        Task<CommentReply> GetCommentReply(int id);
        Task<bool> DeleteCommentReply(int id);
        Task<bool> AddCommentReply(CommentReply reply);
        Task<bool> UpdateCommentReply(CommentReply reply, int id);
        Task<List<CommentReply>> GetAllByComment(int commentId);
    }
}
