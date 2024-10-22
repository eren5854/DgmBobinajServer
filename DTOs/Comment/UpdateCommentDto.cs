namespace DgmBobinajServer.DTOs.Comment;

public sealed record UpdateCommentDto(
    Guid Id,
    string CommentName,
    string CommentText,
    int Rate);
