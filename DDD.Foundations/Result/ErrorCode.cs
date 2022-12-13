namespace DDD.Foundations;

public record class ErrorCode : Enumeration
{
    public string? Message { get; private set; }

    public static readonly ErrorCode Custom = new (0, "Custom error", "");

    protected ErrorCode(int id, string name, string? message = null) : base(id, name) =>
        Message = message;
}
