
namespace DDD.Foundations;

public record class NotificationCollector
{
    public string? Context => string.Join(" >>> ", context);
    private readonly List<string> context = new();
    public void ExtendContext(string fieldName) => context.Add(fieldName);
    public void ReduceContext() => context.RemoveAt(context.Count-1);  

    public IReadOnlyCollection<Error> Errors => errors;
    private readonly List<Error> errors = new();

    public void AddError(InvariantError error, string? fieldName = null) => 
        errors.Add(error with { Details = error.Details + fieldName });

    public bool HasErrors => errors.Count > 0;
    public int ErrorsCount => errors.Count;
}
