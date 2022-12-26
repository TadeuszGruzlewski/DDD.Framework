
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class ValidationContext
{
    public string Name { get; init; }
    [JsonIgnore]
    public ValidationContext? Parent { get; internal init; } = null;
    [JsonIgnore]
    public int ErrorsCount => innerContexts.Sum(c => c.ErrorsCount) + errors.Count;

    public IReadOnlyCollection<InvariantError> Errors => errors;
    private readonly List<InvariantError> errors = new();

    public IReadOnlyCollection<ValidationContext> InnerContexts => innerContexts;
    private readonly List<ValidationContext> innerContexts = new();

    public ValidationContext(string name)
    {
        Name = name;
    }

    public ValidationContext AddInnerContext(string name)
    {
        var context = new ValidationContext(name) { Parent = this };
        innerContexts.Add(context);
        return context;
    }

    public void AddError(InvariantError error) => errors.Add(error);
}
