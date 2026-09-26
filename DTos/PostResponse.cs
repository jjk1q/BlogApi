

namespace Blog.Api.Dtos;

public record PostResponse(int Id, string Title, string Content, DateTime CreatedAt, DateTime? UpdatedAt, bool IsPublished);