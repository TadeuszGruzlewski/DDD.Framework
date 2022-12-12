//namespace DDD.Foundations.Validation;

//public record class ValidationError : Error
//{
//    public new const ValidationError NoError = null;

//    public string? FieldName { get; }

//    //    object IDomainErrorModel.ErrorCode => ErrorCode;

//    //public ValidationError(DomainErrorModel<ValidationErrorCode> original) : base(original)
//    //{ }

//    public ValidationError(ValidationErrorCode code, string message, string? fieldName = null) :
//        base (code, message) => FieldName = fieldName;
//}
