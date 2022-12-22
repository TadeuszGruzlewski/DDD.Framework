
namespace DDD.Foundations;

public record class NotificationCollector
{
    private const string separator = " >>> ";

    private readonly List<string> context = new();
    public string Context => string.Join(separator, context);
    public void ExtendContext(string fieldName) => context.Add(fieldName);
    public void ReduceContext() => context.RemoveAt(context.Count-1);  

    public IReadOnlyCollection<Error> Errors => errors;
    private readonly List<Error> errors = new();

    public void AddError(InvariantErrorCode error, string fieldName, string? details = null) => 
        errors.Add(new InvariantError(error, Context, fieldName, details));

    public bool HasErrors => errors.Count > 0;
    public int ErrorsCount => errors.Count;
}
