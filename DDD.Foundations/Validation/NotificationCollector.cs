using System.Text.Json;
using System.Text.Json.Serialization;

namespace DDD.Foundations;

public class NotificationCollector
{
    public InvariantScope? Scope { get; private set; }

    private InvariantScope? currentScope;

    public void EnterSubScope(string scopeName)
    {
        if (Scope is null)
            currentScope = Scope = new (scopeName);
        else
            currentScope = currentScope?.AddSubScope(scopeName);
    }

    public void LeaveSubScope() => 
        currentScope = currentScope?.Parent;

    public void AddError(string message) => currentScope?.AddError(message);

    public bool HasErrors => ErrorsCount > 0;
    public int ErrorsCount => Scope?.ErrorsCount ?? 0;

    JsonSerializerOptions options = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        WriteIndented = true
    };
    public string? ErrorsAsJson => JsonSerializer.Serialize(Scope, options);
}
