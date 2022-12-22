namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string Details) : Error(ErrorCode);
