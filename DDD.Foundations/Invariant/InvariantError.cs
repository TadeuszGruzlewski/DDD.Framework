namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string ErrorMessage, string Details) : 
    Error(ErrorCode, ErrorMessage);
