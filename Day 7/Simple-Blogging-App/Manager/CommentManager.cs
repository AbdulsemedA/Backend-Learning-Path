using System;
using Simple_Blogging_App.Data;

namespace Simple_Blogging_App.Manager
{
    public class CommentManager
    {
        public void CreateComment(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Text))
                return;
            using var dbContext = new BlogDbContext();
            comment.CreatedAt = DateTime.UtcNow;
            dbContext.Comments.Add(comment);
            dbContext.SaveChanges();
        }

        public Comment GetCommentById(int commentId)
        {
            using var dbContext = new BlogDbContext();
            return dbContext.Comments.SingleOrDefault(c => c.CommentId == commentId);
        }

        public void UpdateComment(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Text))
                return;
                
            using var dbContext = new BlogDbContext();
            var existingComment = dbContext.Comments.Find(comment.CommentId);
            if (existingComment != null)
            {
                existingComment.Text = comment.Text;
                dbContext.SaveChanges();
            }
        }

        public void DeleteComment(int commentId)
        {
            using var dbContext = new BlogDbContext();
            var commentToDelete = dbContext.Comments.Find(commentId);
            if (commentToDelete != null)
            {
                dbContext.Comments.Remove(commentToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}
