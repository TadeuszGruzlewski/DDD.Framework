//namespace DDD.Foundations.Validation;

//public record class ValidationErrorCode : ErrorCode
//{
//    public static readonly ValidationErrorCode ProgrammaticError = new (1, "Programmatic error"); 
//    public static readonly ValidationErrorCode NullOrEmpty = new(2, "Null or empty value");
//    public static readonly ValidationErrorCode WrongType = new(3, "Wrong type");
//    public static readonly ValidationErrorCode WrongFormat = new(4, "Wrong format");

//    protected ValidationErrorCode(int id, string name) : base(id, name) { }
//}

////public enum ValidationErrorCode
////{
////    /// <summary>
////    /// Error is a programming error and will always be thrown as exception
////    /// </summary>
////    ProgrammaticError,
////    /// <summary>
////    /// Value is null, empty value, whitespace only
////    /// </summary>
////    NullOrEmpty,
////    /// <summary>
////    /// Type casting failed
////    /// </summary>
////    IncorrectType,
////    /// <summary>
////    /// Format (regex) validation failed
////    /// </summary>
////    IncorrectFormat,
////    /// <summary>
////    /// Value is below the specified minimum
////    /// </summary>
////    BelowMinimum,
////    /// <summary>
////    /// Value is above the specified maximum
////    /// </summary>
////    AboveMaximum,
////    /// <summary>
////    /// Value does not meet the specified constraints
////    /// </summary>
////    ConstraintViolation,
////    /// <summary>
////    /// Value is conflicting with the value of another parameter
////    /// </summary>
////    ConflictingValue
////}
