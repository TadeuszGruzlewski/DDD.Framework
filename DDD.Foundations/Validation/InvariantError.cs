namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string Context, string Field, string? Details = null) : 
    Error(ErrorCode);
