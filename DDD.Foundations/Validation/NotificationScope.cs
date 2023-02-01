using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    public NotificationScope? Parent { get; private set; } = null;
    [JsonIgnore]
    public int ErrorsCount => errors.Count + subcopes.Sum(s => s.ErrorsCount);

    public IReadOnlyCollection<string> Errors => errors;
    private readonly List<string> errors = new();

    public IReadOnlyCollection<NotificationScope> Subscopes => subcopes;
    private readonly List<NotificationScope> subcopes = new();

    internal NotificationScope(string? name) => Name = name;

    internal NotificationScope AddSubscope(string? name)
    {
        var scope = new NotificationScope(name) { Parent = this };
        subcopes.Add(scope);
        return scope;
    }

    internal void AddError(string message) => errors.Add(message);
}
