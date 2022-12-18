namespace DDD.Foundations;

public record class ErrorCode : Enumeration
{
    protected ErrorCode(int Code, string Name) : base(Code, Name) { }

    public static readonly ErrorCode NoError = new (0, "No error");
}
