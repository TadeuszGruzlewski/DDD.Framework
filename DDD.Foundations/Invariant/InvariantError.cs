namespace DDD.Foundations;

public record class InvariantError(InvariantErrorCode ErrorCode, string ErrorMessage, string? FieldName = null) : 
    Error(ErrorCode, ErrorMessage);
