using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_App_API.Controllers;
using Blog_App_API.Data;
using Blog_App_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Blog_App_API.Tests
{
    public class CommentsControllerTests
    {
        
        public DbContextOptions<BlogDbContext> CreateContext()
        {
            return new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetComments_ReturnsListOfComments()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.Comments.Add(new Comment { CommentId = 2, Text = "Test Comment 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.GetComments();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var comments = Assert.IsAssignableFrom<List<Comment>>(okResult.Value);
                Assert.Equal(2, comments.Count);
            }
        }

        [Fact]
        public async Task GetCommentByValidId_ReturnsComment()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.GetComment(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var comment = Assert.IsAssignableFrom<Comment>(okResult.Value);
                Assert.Equal(1, comment.CommentId);
            }
        }

        [Fact]
        public async Task GetCommentByInvalidId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.GetComment(2);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task CreateCommentWithExistingPost_ReturnsCreatedComment()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.CreateComment(1, new Comment { CommentId = 1, Text = "Test Comment 1" });

                // Assert
                var okResult = Assert.IsType<CreatedAtActionResult>(result);
                var comment = Assert.IsAssignableFrom<Comment>(okResult.Value);
                Assert.Equal(1, comment.CommentId);
            }
        }

        [Fact]
        public async Task CreateCommentWithNonExistingPost_ReturnsCreatedComment()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.CreateComment(2, new Comment { CommentId = 1, Text = "Test Comment 1" });

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task UpdateCommentByValidId_ReturnsNoText()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.UpdateComment(1, "Test Comment 2" );

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }

        [Fact]
        public async Task UpdateCommentByInvalidId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.UpdateComment(2, "Test Comment 2" );

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task DeleteCommentByValidId_ReturnsDeletedComment()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.DeleteComment(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var comment = Assert.IsAssignableFrom<Comment>(okResult.Value);
                Assert.Equal(1, comment.CommentId);
            }
        }

        [Fact]
        public async Task DeleteCommentByInvalidId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Comments.Add(new Comment { CommentId = 1, Text = "Test Comment 1" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new CommentsController(context);

                // Act
                var result = await controller.DeleteComment(2);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}