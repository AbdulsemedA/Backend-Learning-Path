using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog_App_API.Data;
using Blog_App_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_App_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly BlogDbContext dbContext;

    public PostsController(BlogDbContext context)
    {
        dbContext = context;
    }

    // GET: api/posts
    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await dbContext.Posts.ToListAsync();
        return Ok(posts);
    }

    // GET: api/posts/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id)
    {
        var post = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);

        if (!PostExists(id))
            return NotFound();

        return Ok(post);
    }

    // POST: api/posts
    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        await dbContext.Posts.AddAsync(post);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction("GetPost", new { id = post.PostId }, post);
    }

    // PUT: api/posts/id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        var postToUpdate = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        
        if (postToUpdate == null)
            return BadRequest();

        if (!PostExists(id))
            return NotFound();

        postToUpdate.Title = post.Title;
        postToUpdate.Content = post.Content;
        postToUpdate.CreatedAt = DateTime.UtcNow;

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PostExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/posts/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        if (!PostExists(id) || post == null)
            return NotFound();

        dbContext.Posts.Remove(post);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool PostExists(int id)
    {
        return dbContext.Posts.Any(p => p.PostId == id);
    }
}