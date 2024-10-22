namespace DgmBobinajServer.Models;

public sealed class Comment : Entity
{
    public string CommentName { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public int Rate { get; set; } = 0;
    public bool IsUpdateable { get; set; } = true;
}
