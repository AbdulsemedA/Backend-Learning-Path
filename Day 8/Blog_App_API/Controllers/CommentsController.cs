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
public class CommentsController : ControllerBase
{
    private readonly BlogDbContext dbContext;

    public CommentsController(BlogDbContext context)
    {
        dbContext = context;
    }

    // GET: api/comments
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var comments = await dbContext.Comments.ToListAsync();
        return Ok(comments);
    }

    // GET: api/comments/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var comment = await dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == id);

        if (!CommentExists(id))
            return NotFound();

        return Ok(comment);
    }

    // POST: api/comments
    [HttpPost("{id}")]
    public async Task<IActionResult> CreateComment(int id, Comment comment)
    {
        var post = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);

        if (post == null)
            return StatusCode(404, "Post not found");
        
        comment.PostId = id;
        await dbContext.Comments.AddAsync(comment);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
    }

    // PUT: api/comments/id
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateComment(int id, string comment)
    {
        var commentToUpdate = await dbContext.Comments.FindAsync(id);

        if (commentToUpdate == null)
            return BadRequest();
        
        commentToUpdate.Text = comment;
        dbContext.Entry(commentToUpdate).State = EntityState.Modified;

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommentExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/comments/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await dbContext.Comments.FindAsync(id);
        if (!CommentExists(id) || comment == null) // Check for null
        return NotFound();

        dbContext.Comments.Remove(comment);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    private bool CommentExists(int id)
    {
        return dbContext.Comments.Any(e => e.CommentId == id);
    }
}
