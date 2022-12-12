namespace DDD.Foundations;

public record class Error(ErrorCode Code, string Message) : Result;
