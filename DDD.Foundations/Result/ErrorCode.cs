namespace DDD.Foundations;

public record class ErrorCode : Enumeration
{
    public string? Message { get; private set; }

    public static readonly ErrorCode NoError = new (0, "No error", "");

    protected ErrorCode(int id, string name, string? message = null) : base(id, name) =>
        Message = message;
}
