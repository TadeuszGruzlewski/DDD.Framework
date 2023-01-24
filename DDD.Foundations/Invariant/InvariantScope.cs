using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class InvariantScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    internal InvariantScope? Parent { get; private set; } = null;
    [JsonIgnore]
    public int ErrorsCount => embeddedScopes.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<string> Errors => errors;
    private readonly List<string> errors = new();

    public IReadOnlyCollection<InvariantScope> EmbeddedScopes => embeddedScopes;
    private readonly List<InvariantScope> embeddedScopes = new();

    internal InvariantScope(string name)
    {
        Name = name;
    }

    internal InvariantScope AddEmbeddedScope(string name)
    {
        var scope = new InvariantScope(name) { Parent = this };
        embeddedScopes.Add(scope);
        return scope;
    }

    internal void AddError(string message) => errors.Add(message);
}
