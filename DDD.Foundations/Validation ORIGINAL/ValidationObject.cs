//namespace DDD.Foundations.ValidationORIGINAL;

//public abstract record class ValidationObject
//{
//    public bool IsValidated { get; private set; }
//    public bool IsValid => !Errors.Any();

//    public IReadOnlyCollection<ValidationError> Errors => errors;
//    private readonly List<ValidationError> errors = new();

//    protected abstract IEnumerable<Func<ValidationError?>> GetValidationRequirements();

//    private INotificationCollector? collector;

//    protected void Validate(INotificationCollector? notificationCollector = null)
//    {
//        if (IsValidated) return;

//        collector = notificationCollector;

//        foreach (var requirementValidator in GetValidationRequirements())
//            ValidateRequirement(requirementValidator);

//        IsValidated = true;
//    }

//    private void ValidateRequirement(Func<ValidationError> requirementValidator)
//    {
//        var validationError = requirementValidator();

//        if (validationError != null)
//        {
//            if (validationError.ErrorCode == ValidationErrorCode.ProgrammaticError)
//                throw new ArgumentException(validationError.Message, validationError.PropertyName);

//            errors.Add(validationError);
//            collector?.AddError(validationError);
//        }
//    }
//}



////public abstract record class ValidationObject
////{
////    public static readonly IEnumerable<Func<ValidationError>> NoRequirements = Array.Empty<Func<ValidationError>>();

////    public bool IsValidated { get; private set; }
////    public IReadOnlyCollection<ValidationError> Errors => errors;
////    public bool IsValid => !Errors.Any();

////    protected abstract IEnumerable<Func<ValidationError>> GetValidationRequirements();

////    private readonly List<ValidationError> errors = new();
////    private INotificationCollector? collector;

////    protected void Validate(INotificationCollector? notificationCollector = null)
////    {
////        if (IsValidated) return;

////        collector = notificationCollector;

////        foreach (var requirementValidator in GetValidationRequirements())
////            ValidateRequirement(requirementValidator);

////        IsValidated = true;

////        if (notificationCollector == null)
////        {
////            var validationExceptions = errors.Select(x => new ArgumentException(x.Message, x.PropertyName)).ToList();

////            if (validationExceptions.Count == 1)
////                throw validationExceptions.First();

////            if (validationExceptions.Count > 1)
////                throw new AggregateException(validationExceptions);
////        }
////    }

////    private void ValidateRequirement(Func<ValidationError> requirementValidator)
////    {
////        var validationError = requirementValidator();

////        if (validationError != null)
////        {
////            if (validationError.ErrorCode == ValidationErrorCode.ProgrammaticError)
////                throw new ArgumentException(validationError.Message, validationError.PropertyName);

////            errors.Add(validationError);
////            collector?.AddError(validationError);
////        }
////    }
////}

