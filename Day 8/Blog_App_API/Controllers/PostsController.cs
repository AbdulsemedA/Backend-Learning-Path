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
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        return await dbContext.Posts.ToListAsync();
    }

    // GET: api/posts/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await dbContext.Posts.FindAsync(id);

        if (!PostExists(id))
            return NotFound();

        return post!;
    }

    // POST: api/posts
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        dbContext.Posts.Add(post);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction("GetPost", new { id = post.PostId }, post);
    }

    // PUT: api/posts/id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.PostId)
            return BadRequest();

        dbContext.Entry(post).State = EntityState.Modified;

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
        var post = await dbContext.Posts.FindAsync(id);
        if (!PostExists(id))
            return NotFound();

        dbContext.Posts.Remove(post!);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool PostExists(int id)
    {
        return dbContext.Posts.Any(e => e.PostId == id);
    }
}