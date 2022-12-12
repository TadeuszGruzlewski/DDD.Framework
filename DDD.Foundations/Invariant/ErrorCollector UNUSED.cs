//namespace DDD.Foundations.Invariants;

//public sealed class ErrorCollector // : INotificationCollector
//{
//    private readonly List<InvariantError> _errors = new();

//    public void AddError(InvariantError error) => _errors.Add(error);

//    public bool HasErrors() => _errors.Any();

//    //public DomainProblemDetails<IDomainErrorModel> GetErrors()
//    //{
//    //    var errors = new Errors<IDomainErrorModel>
//    //    {
//    //        Global = _errors
//    //                 .Where(x => x.PropertyName is null)
//    //                 .Distinct()
//    //                 .ToList(),
//    //        Field = _errors
//    //                         .Where(x => x.PropertyName is not null)
//    //                         .GroupBy(x => x.PropertyName ?? "unknown")
//    //                         .ToDictionary(g => g.Key, g => g.ToList())
//    //    };

//    //    return new InternalDomainProblemDetails(errors);
//    //}
//}
