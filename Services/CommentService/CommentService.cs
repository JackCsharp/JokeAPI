namespace JokeAPI.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;
        public CommentService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;
            comment.Text = "Comment was deleted";
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<Comment>> GetCommentsByJoke(int jokeId)
        {
            var comments = await _context.Comments.Where(c => c.JokeId == jokeId).ToListAsync();
            if (comments == null) return null;
            return comments;
        }

        public async Task<Comment> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;
            return comment;
        }

        public async Task<bool> UpdateComment(Comment request, int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;

            comment.Text = request.Text;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<CommentReply>> GetAllReplies(int id)
        {
            var replys = await _context.CommentsReplies.Where(r => r.CommentId == id).ToListAsync();
            return replys;
        }
    }
}
