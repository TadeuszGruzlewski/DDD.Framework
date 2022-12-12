namespace DDD.Primitives.Messages;

public record class ErrorMessage : Message
{
    private ErrorMessage(int code, string name, string text) : base(code, name, text) { }

    public static readonly ErrorMessage ConnectionError = new(10, "Connection", "????????????");
}
