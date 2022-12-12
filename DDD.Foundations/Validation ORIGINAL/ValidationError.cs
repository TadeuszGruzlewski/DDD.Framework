//namespace DDD.Foundations.ValidationORIGINAL;

//public enum ValidationErrorCode
//{
//    /// <summary>
//    /// Error is a programming error and will always be thrown as exception
//    /// </summary>
//    ProgrammaticError,
//    /// <summary>
//    /// Value is null, empty value, whitespace only
//    /// </summary>
//    NullOrEmpty,
//    /// <summary>
//    /// Type casting or Format (regex) validation failed
//    /// </summary>
//    IncorrectTypeOrFormat,
//    /// <summary>
//    /// Value is below the specified minimum
//    /// </summary>
//    BelowMinimum,
//    /// <summary>
//    /// Value is above the specified maximum
//    /// </summary>
//    AboveMaximum,
//    /// <summary>
//    /// Value does not meet the specified constraints
//    /// </summary>
//    ConstraintViolation,
//    /// <summary>
//    /// Value is conflicting with the value of another parameter
//    /// </summary>
//    ConflictingValue
//}

//public record class ValidationError : DomainErrorModel<ValidationErrorCode>
//{
//    public const ValidationError NoError = null;

//    public ValidationError(DomainErrorModel<ValidationErrorCode> original) : base(original)
//    { }

//    public ValidationError(ValidationErrorCode errorCode, string message, string? propertyName = null) : 
//        base(errorCode, message, propertyName)
//    { }
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
////    /// Type casting or format (regex) validation failed
////    /// </summary>
////    IncorrectTypeOrFormat,
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

////public record class ValidationError : DomainErrorModel<ValidationErrorCode>
////{
////    public const ValidationError NoError = null;

////    public ValidationError(DomainErrorModel<ValidationErrorCode> original) : base(original)
////    {
////    }

////    public ValidationError(ValidationErrorCode errorCode, string message) : base(errorCode, message)
////    {
////    }

////    public ValidationError(ValidationErrorCode errorCode, string message, string propertyName) : base(errorCode, message, propertyName)
////    {
////    }
////}