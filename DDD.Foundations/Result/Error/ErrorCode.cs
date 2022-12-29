namespace DDD.Foundations;

public record class E(string Text);

public record class ErrorCode : E// : Enumeration
{
    //    protected ErrorCode(int Code, string Text) : base(Code, Text) { }
    protected ErrorCode(string Text) : base(Text) { }

    public static readonly ErrorCode NoError = new ("No error");
}
