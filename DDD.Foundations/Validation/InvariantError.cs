namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string Field, string? Details = null) : 
    Error(ErrorCode);
