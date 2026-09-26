namespace Blog.Api.Models;
public class Post
{
    public int Id{get;private set;}
    public string Title{get;private set;}
    public string Content{get;private set;}
    public DateTime CreatedAt{get;private set;}
    public DateTime? UpdatedAt{get;private set;}
    public bool IsPublished{get;private set;}
    
    public Post(string title, string content)
    {
        Validate(title, content);
        
        CreatedAt = DateTime.UtcNow;
        IsPublished = false;
        Title = title;
        Content = content;

    }

    private Post(){ Title = null!; Content = null!;}

    public void Update(string title, string content)
    {
        Validate(title, content);
        
        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }

    private static void Validate(string title, string content)
    {
        if(string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("title cannot be empty", nameof(title));
        if(string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("content cannot be empty", nameof(content));
        
    }

    public void Publish() => IsPublished = true;
    public void Unpublish() => IsPublished = false;
}

