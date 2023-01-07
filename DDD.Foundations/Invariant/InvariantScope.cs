
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class InvariantScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    public InvariantScope? Parent { get; internal init; } = null;
    [JsonIgnore]
    public int ErrorsCount => subScopes.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<string> Errors => errors;
    private readonly List<string> errors = new();

    public IReadOnlyCollection<InvariantScope> SubScopes => subScopes;
    private readonly List<InvariantScope> subScopes = new();

    public InvariantScope(string name)
    {
        Name = name;
    }

    public InvariantScope AddSubScope(string name)
    {
        var scope = new InvariantScope(name) { Parent = this };
        subScopes.Add(scope);
        return scope;
    }

    public void AddError(string message) => errors.Add(message);
}
