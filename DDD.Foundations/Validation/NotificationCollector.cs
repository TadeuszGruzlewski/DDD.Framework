using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public record class NotificationCollector
{
    public ValidationContext Context { get; init; }

    private ValidationContext currentContext;

    public NotificationCollector(string name) => currentContext = Context = new(name);

    public void ExtendContext(string fieldName) => 
        currentContext = Context.AddInnerContext(fieldName);
    public void ReduceContext()
    {
        if (currentContext.Parent is not null)
            currentContext = currentContext.Parent;
    }

    public void AddError(InvariantErrorCode error, string fieldName, string? details = null) =>
        currentContext?.AddError(new InvariantError(error, fieldName, details));

    public bool HasErrors => ErrorsCount > 0;
    public int ErrorsCount => currentContext.ErrorsCount;

    //    public string Errors => "{ " + Context.Name + " }";

    JsonSerializerOptions options = new()
    {

        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        WriteIndented = true
    };
    public string ErrorsAsJson => JsonSerializer.Serialize(Context, options);
}



//public record class NotificationCollector
//{
//    private const string separator = " >>> ";

//    private readonly List<string> context = new();
//    public string Context => string.Join(separator, context);
//    public void ExtendContext(string fieldName) => context.Add(fieldName);
//    public void ReduceContext() => context.RemoveAt(context.Count - 1);

//    public IReadOnlyCollection<InvariantError> Errors => errors;
//    private readonly List<InvariantError> errors = new();

//    public void AddError(InvariantErrorCode error, string fieldName, string? details = null) =>
//        errors.Add(new InvariantError(error, Context, fieldName, details));

//    public bool HasErrors => errors.Count > 0;
//    public int ErrorsCount => errors.Count;
//}
