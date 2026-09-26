namespace Blog.Api.Data;

using Microsoft.EntityFrameworkCore;
using Blog.Api.Models;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

    public DbSet<Post> Posts => Set<Post>();
}