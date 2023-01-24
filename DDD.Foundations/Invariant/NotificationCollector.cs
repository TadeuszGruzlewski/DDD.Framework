using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationCollector
{
    private InvariantScope? rootScope;
    private InvariantScope? currentScope;

    internal void EnterEmbeddedScope(string scopeName)
    {
        if (rootScope is null)
            currentScope = rootScope = new(scopeName);
        else
            currentScope = currentScope?.AddEmbeddedScope(scopeName);
    }

    internal void ExitEmbeddedScope() => 
        currentScope = currentScope?.Parent;

    public void AddError(string message) => currentScope?.AddError(message);

    public bool HasErrors => ErrorsCount > 0;
    public int ErrorsCount => rootScope?.ErrorsCount ?? 0;

    private JsonSerializerOptions options = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        WriteIndented = true
    };
    public string? ErrorsAsJson => JsonSerializer.Serialize(rootScope, options);
}
