namespace uTimePlatform.Reviews.Domain.Model.ValueObjects;
public record Comment
{
    public string Content { get; }
    public Comment() : this(string.Empty) {}
    public Comment(string content)
    {
        Content = content;
    }
    public override string ToString() => Content;
}