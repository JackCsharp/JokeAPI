namespace JokeAPI.Services.CommentReplyService
{
    public class CommentReplyService : ICommentReplyService
    {
        DataContext _context;
        public CommentReplyService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCommentReply(CommentReply reply)
        {
            _context.CommentsReplies.Add(reply);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentReply(int id)
        {
            var comment = await _context.CommentsReplies.FindAsync(id);
            if (comment == null) return false;
            comment.Text = "Reply was deleted";
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CommentReply> GetCommentReply(int id)
        {
            var reply = await _context.CommentsReplies.FindAsync(id);
            if (reply == null) return null;
            return reply;
        }
        public async Task<List<CommentReply>> GetAllByComment(int commentId)
        {
                var replies = await _context.CommentsReplies.Where(c => c.CommentId == commentId).ToListAsync();
                if (replies == null) return null;
                return replies;
        }

        public async Task<bool> UpdateCommentReply(CommentReply request, int id)
        {
            var reply = _context.CommentsReplies.Find(id);
            if (reply == null) return false;

            reply.Text=request.Text;
            return true;
        }
    }
}
