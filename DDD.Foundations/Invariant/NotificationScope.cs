using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    public NotificationScope? Parent { get; private set; } = null;
    [JsonIgnore]
    public int ErrorsCount => embeddedScopes.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<string> Errors => errors;
    private readonly List<string> errors = new();

    public IReadOnlyCollection<NotificationScope> EmbeddedScopes => embeddedScopes;
    private readonly List<NotificationScope> embeddedScopes = new();

    internal NotificationScope(string? name) => Name = name;

    internal NotificationScope AddEmbeddedScope(string? name)
    {
        var scope = new NotificationScope(name) { Parent = this };
        embeddedScopes.Add(scope);
        return scope;
    }

    internal void AddError(string message) => errors.Add(message);
}
