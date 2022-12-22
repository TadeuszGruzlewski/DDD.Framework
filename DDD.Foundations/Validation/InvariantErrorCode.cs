namespace DDD.Foundations;

public record class InvariantErrorCode : ErrorCode
{
    protected InvariantErrorCode(int Code, string Text) : base(Code, Text) { }

    /// <summary>
    /// Programming error (always thrown as exception)
    /// </summary>
    public static readonly InvariantErrorCode ProgrammaticError = new (1, "Programmatic error");

    /// <summary>
    /// Null reference error
    /// </summary>
    public static readonly InvariantErrorCode NullReference = new(10, "Null reference: ");
    /// <summary>
    /// Null argument error
    /// </summary>
    public static readonly InvariantErrorCode NullArgument = new(11, "Null argument: ");

    /// <summary>
    /// Value is null, empty, or whitespace
    /// </summary>
    public static readonly InvariantErrorCode NullOrEmpty = new(20, "Null or empty value");
    /// <summary>
    /// Type check error
    /// </summary>
    public static readonly InvariantErrorCode WrongType = new(21, "Wrong type");
    /// <summary>
    /// Format (regex) validation error
    /// </summary>
    public static readonly InvariantErrorCode WrongFormat = new(22, "Wrong format");

    /// <summary>
    /// Value is outside the specified range
    /// </summary>
    public static readonly InvariantErrorCode OutsideRange = new(30, "Outside range");
    /// Value is below the specified minimum
    /// </summary>
    public static readonly InvariantErrorCode BelowMinimum = new(31, "Below minimum");
    /// Value is above the specified maximum
    /// </summary>
    public static readonly InvariantErrorCode AboveMaximum = new(32, "Above maximum");

    /// <summary>
    /// Value does not meet the specified constraints
    /// </summary>
    public static readonly InvariantErrorCode ConstraintViolation = new(40, "Constraint violation");

    /// <summary>
    /// Value is conflicting with another value of another parameter
    /// </summary>
    public static readonly InvariantErrorCode ConflictingValues = new(41, "Conflicting values");
}



//public record class InvariantErrorCode : ErrorCode
//{
//    protected InvariantErrorCode(int Code, string Name) : base(Code, Name) { }

//    /// <summary>
//    /// Programming error (always thrown as exception)
//    /// </summary>
//    public static readonly InvariantErrorCode ProgrammaticError = new(1, "Programmatic error");

//    /// <summary>
//    /// Null reference error
//    /// </summary>
//    public static readonly InvariantErrorCode NullReference = new(10, "Null reference error");
//    /// <summary>
//    /// Null argument error
//    /// </summary>
//    public static readonly InvariantErrorCode NullArgument = new(11, "Null argument error");

//    /// <summary>
//    /// Value is null, empty, or whitespace
//    /// </summary>
//    public static readonly InvariantErrorCode NullOrEmpty = new(20, "Null or empty value");
//    /// <summary>
//    /// Type check error
//    /// </summary>
//    public static readonly InvariantErrorCode WrongType = new(21, "Wrong type");
//    /// <summary>
//    /// Format (regex) validation error
//    /// </summary>
//    public static readonly InvariantErrorCode WrongFormat = new(22, "Wrong format");

//    /// <summary>
//    /// Value is outside the specified range
//    /// </summary>
//    public static readonly InvariantErrorCode OutsideRange = new(30, "Outside range");
//    /// Value is below the specified minimum
//    /// </summary>
//    public static readonly InvariantErrorCode BelowMinimum = new(31, "Below minimum");
//    /// Value is above the specified maximum
//    /// </summary>
//    public static readonly InvariantErrorCode AboveMaximum = new(32, "Above maximum");

//    /// <summary>
//    /// Value does not meet the specified constraints
//    /// </summary>
//    public static readonly InvariantErrorCode ConstraintViolation = new(40, "Constraint violation");

//    /// <summary>
//    /// Value is conflicting with another value of another parameter
//    /// </summary>
//    public static readonly InvariantErrorCode ConflictingValues = new(41, "Conflicting values");
//}

