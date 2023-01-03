
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class ValidationScope
{
    public string? Name { get; init; }
    [JsonIgnore]
    public ValidationScope? Parent { get; internal init; } = null;
    [JsonIgnore]
    public int ErrorsCount => subScopes.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<InvariantError> Errors => errors;
    private readonly List<InvariantError> errors = new();

    public IReadOnlyCollection<ValidationScope> SubScopes => subScopes;
    private readonly List<ValidationScope> subScopes = new();

    public ValidationScope(string name)
    {
        Name = name;
    }

    public ValidationScope AddSubScope(string name)
    {
        var scope = new ValidationScope(name) { Parent = this };
        subScopes.Add(scope);
        return scope;
    }

    public void AddError(string message) => errors.Add(new(message));
}
