namespace DDD.Foundations;

public class ValidationContext
{
    public string Name { get; init; }
    public ValidationContext? Parent { get; internal init; } = null;

    public IReadOnlyCollection<ValidationContext> InnerContexts => innerContexts;
    private readonly List<ValidationContext> innerContexts = new();

    public IReadOnlyCollection<InvariantError> Errors => errors;
    private readonly List<InvariantError> errors = new();

    public ValidationContext(string name)
    {
        Name = name;
        //Parent = null;
    }

    public ValidationContext AddInnerContext(string name)
    {
        var context = new ValidationContext(name) { Parent = this };
        innerContexts.Add(context);
        return context;
    }

    public void AddError(InvariantError error) => errors.Add(error);

    public int ErrorsCount => innerContexts.Sum(c => c.ErrorsCount) + errors.Count;
}
