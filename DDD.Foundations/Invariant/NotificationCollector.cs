using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationCollector
{
    public InvariantScope? RootScope { get; private set; }
    private InvariantScope? CurrentScope;

    internal void EnterEmbeddedScope(string scopeName)
    {
        if (RootScope is null)
            CurrentScope = RootScope = new(scopeName);
        else
            CurrentScope = CurrentScope?.AddEmbeddedScope(scopeName);
    }

    internal void ExitEmbeddedScope() => 
        CurrentScope = CurrentScope?.Parent;

    public void AddError(string message) => CurrentScope?.AddError(message);

    public bool HasErrors => ErrorsCount > 0;
    public int ErrorsCount => RootScope?.ErrorsCount ?? 0;

    private JsonSerializerOptions options = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        WriteIndented = true
    };
    public string? ErrorsAsJson => JsonSerializer.Serialize(RootScope, options);
}
