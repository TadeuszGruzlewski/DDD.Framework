
namespace DDD.Foundations;

public record class NotificationCollector
{
    public string? Context { get; private set; }
    public void ExpandContext(string fieldName) =>
        Context = (Context is null ? "" : Context + " >>> ") + fieldName;
    public void ReduceContext() =>
        Context = Context?[..(Context?.LastIndexOf(" >>> ") == -1 ? 0 : Context!.Length)];   

    public IReadOnlyCollection<Error> Errors => errors;
    private readonly List<Error> errors = new();

    public void AddError(InvariantError error, string? fieldName = null) => 
        errors.Add(error with { Details = error.Details + fieldName });

    public bool HasErrors => errors.Count > 0;
    public int ErrorsCount => errors.Count;
}
