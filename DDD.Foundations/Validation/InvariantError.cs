namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string Message, string Details) : 
    Error(ErrorCode, Message);
