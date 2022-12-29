using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public record class NotificationCollector
{
    public ValidationContext Context { get; init; }

    private ValidationContext currentContext;

    public NotificationCollector(string objectName) => currentContext = Context = new(objectName);

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
