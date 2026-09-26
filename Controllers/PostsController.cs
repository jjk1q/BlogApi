using System.Data.Common;
using Blog.Api.Data;
using Blog.Api.Dtos;
using Blog.Api.Models;
using Microsoft.AspNetCore.Mvc;
namespace Blog.Api.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly BlogDbContext _db;

    public PostsController(BlogDbContext db)
    {
        _db = db;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PostResponse>> GetById(int id)
    {
        var post = await _db.Posts.FindAsync(id);
        if(post == null) return NotFound();
        return ToResponse(post);
    }
    
    [HttpPost]
    public async Task<ActionResult<PostResponse>> Create(CreatePostRequest request)
    {
        Post post;
        try
        {
            post = new Post(request.Title, request.Content);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new{id = post.Id}, ToResponse(post));

    }

    private static PostResponse ToResponse(Post post)
    {
        return new PostResponse(post.Id, post.Title, post.Content, post.CreatedAt, post.UpdatedAt, post.IsPublished);
    }
    
}