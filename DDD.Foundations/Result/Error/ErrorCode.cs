namespace DDD.Foundations;

public record class ErrorCode : Enumeration
{
    protected ErrorCode(int Code, string Text) : base(Code, Text) { }

    public static readonly ErrorCode NoError = new (0, "No error");
}
