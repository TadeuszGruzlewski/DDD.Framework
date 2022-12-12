//using System.Text.Json.Serialization;

//namespace DDD.Foundations.ValidationORIGINAL;

///// <summary>
///// This is a abstract record for the domain error model
///// </summary>
///// <remarks>
///// Implement this abstract class and use it to add errors to the NotificationCollector
///// </remarks>
///// <typeparam name="TErrorCode">Enum of error codes specific for your domain</typeparam>
//public abstract record class DomainErrorModel<TErrorCode> : IDomainErrorModel where TErrorCode : Enum
//{
//    public TErrorCode ErrorCode { get; }
//    public string Message { get; }
//    [JsonIgnore]
//    public string? PropertyName { get; }

//    object IDomainErrorModel.ErrorCode => ErrorCode;

//    protected DomainErrorModel(TErrorCode errorCode, string message, string? propertyName = null) =>
//        (ErrorCode, Message, PropertyName) = (errorCode, message, propertyName);
//}




////public abstract record class DomainErrorModel<TErrorCode> : IDomainErrorModel where TErrorCode : Enum
////{
////    public TErrorCode ErrorCode { get; }
////    public string Message { get; }
////    [JsonIgnore]
////    public string? PropertyName { get; }

////    object IDomainErrorModel.ErrorCode => ErrorCode;

////    protected DomainErrorModel(TErrorCode errorCode, string message)
////    {
////        ErrorCode = errorCode;
////        Message = message;
////        PropertyName = null;
////    }

////    protected DomainErrorModel(TErrorCode errorCode, string message, string propertyName)
////    {
////        ErrorCode = errorCode;
////        Message = message;
////        PropertyName = propertyName;
////    }
////}