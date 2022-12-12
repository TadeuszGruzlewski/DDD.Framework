//using Microsoft.AspNetCore.Mvc;

//namespace DDD.Foundations.ValidationORIGINAL;

///// <summary>
///// This is a abstract class for formatting the errors
///// </summary>
///// <remarks>
///// Implement this abstract class specifically for OpenApi specification
///// </remarks>
///// <typeparam name="TDomainErrorModel">Implementation of DomainErrorModel<TEnum></typeparam>
//public abstract class DomainProblemDetails<TDomainErrorModel> : ProblemDetails where TDomainErrorModel : IDomainErrorModel
//{
//    protected DomainProblemDetails(Errors<TDomainErrorModel> errors) => Errors = errors;

//    public Errors<TDomainErrorModel> Errors { get; set; }
//}
