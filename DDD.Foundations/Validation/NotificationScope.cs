using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    public NotificationScope? Parent { get; private set; } = null;
    [JsonIgnore]
    public int ErrorsCount => innerScopes.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<string> Errors => errors;
    private readonly List<string> errors = new();

    public IReadOnlyCollection<NotificationScope> InnerScopes => innerScopes;
    private readonly List<NotificationScope> innerScopes = new();

    internal NotificationScope(string? name) => Name = name;

    internal NotificationScope AddInnerScope(string? name)
    {
        var scope = new NotificationScope(name) { Parent = this };
        innerScopes.Add(scope);
        return scope;
    }

    internal void AddError(string message) => errors.Add(message);
}
