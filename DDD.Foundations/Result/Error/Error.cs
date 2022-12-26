namespace DDD.Foundations;

public record class Error(ErrorCode Code) : Result;
