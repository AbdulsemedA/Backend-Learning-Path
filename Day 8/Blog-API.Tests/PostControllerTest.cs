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
    public class PostsControllerTests
    {

        public DbContextOptions<BlogDbContext> CreateContext()
        {
            return new DbContextOptionsBuilder<BlogDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetPosts_ReturnsListOfPosts()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.GetPosts();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var posts = Assert.IsAssignableFrom<List<Post>>(okResult.Value);
                Assert.Equal(2, posts.Count);
            }
        }

        [Fact]
        public async Task GetPostByValidId_ReturnsPost()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.GetPost(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var post = Assert.IsAssignableFrom<Post>(okResult.Value);
                Assert.Equal(1, post.PostId);
            }
        }

        [Fact]
        public async Task GetPostByNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.GetPost(3);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task PostPost_ReturnsCreatedPost()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.CreatePost(new Post { PostId = 3, Title = "Test Post 3" });

                // Assert
                var okResult = Assert.IsType<CreatedAtActionResult>(result);
                var post = Assert.IsAssignableFrom<Post>(okResult.Value);
                Assert.Equal(3, post.PostId);
            }
        }

        [Fact]
        public async Task PutPostByValidId_ReturnsNoContent()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.UpdatePost(1, new Post { PostId = 1, Title = "Test Post 1 Updated" });

                // Assert
                Assert.IsType<NoContentResult>(result);
            }
        }

        [Fact]
        public async Task PutPostByNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.UpdatePost(3, new Post { PostId = 3, Title = "Test Post 3" });

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task DeletePostByValidId_ReturnsDeletedPost()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.DeletePost(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var post = Assert.IsAssignableFrom<Post>(okResult.Value);
                Assert.Equal(1, post.PostId);
            }
        }

        [Fact]
        public async Task DeletePostByNonExistingId_ReturnsNotFound()
        {
            // Arrange
            var contextOption = CreateContext();

            using (var context = new BlogDbContext(contextOption))
            {
                context.Posts.Add(new Post { PostId = 1, Title = "Test Post 1" });
                context.Posts.Add(new Post { PostId = 2, Title = "Test Post 2" });
                context.SaveChanges();
            }

            using (var context = new BlogDbContext(contextOption))
            {
                var controller = new PostsController(context);

                // Act
                var result = await controller.DeletePost(3);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}
