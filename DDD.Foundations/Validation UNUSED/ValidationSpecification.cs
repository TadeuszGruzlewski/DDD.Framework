//namespace DDD.Foundations.Validation;

//public abstract record class ValidationSpecification;

//public record class NullOrEmpty(string Field, string Name) : ValidationSpecification
//{
//    public ValidationError Validate() =>
//        string.IsNullOrWhiteSpace(Field) ?
//        new(ValidationErrorCode.NullOrEmpty, $"{Name} cannot be null or empty", Name) :
//        ValidationError.NoError;
//}

//public record class PositiveInt(string Field, string Name) : ValidationSpecification
//{
//    public ValidationError Validate() =>
//        string.IsNullOrWhiteSpace(Field) ?
//        new(ValidationErrorCode.NullOrEmpty, $"{Name} cannot be null or empty", Name) :
//        !(int.TryParse(Field, out var number) && number >= 0) ?
//        new (ValidationErrorCode.WrongType, $"{Name} must be positive integer number", Name) :
//        ValidationError.NoError;
//}

//public record class Validated(ValueObject ValueObject, string Name) : ValidationSpecification
//{
//    public ValidationError Validate() =>
//        !ValueObject.IsValidated ? 
//        new (ValidationErrorCode.ProgrammaticError, $"{Name} must be validated", Name) :
//        ValidationError.NoError;
//}

////public record class ValidatedEntity(Entity Entity, string Name) : ValidationSpecification
////{
////    public ValidationError Validate() =>
////        !Entity.IsValidated ?
////        new(ValidationErrorCode.ProgrammaticError, $"{Name} must be validated", Name) :
////        ValidationError.NoError;
////}
