//namespace DDD.Foundations.ValidationORIGINAL;

//public sealed class NotificationCollector : INotificationCollector
//{
//    private readonly List<IDomainErrorModel> _errors = new();

//    public void AddError(IDomainErrorModel error) => _errors.Add(error);

//    public bool HasErrors() => _errors.Any();

//    public DomainProblemDetails<IDomainErrorModel> GetErrors()
//    {
//        var errors = new Errors<IDomainErrorModel>
//        {
//            Global = _errors
//                     .Where(x => x.PropertyName is null)
//                     .Distinct()
//                     .ToList(),
//            Field = _errors
//                             .Where(x => x.PropertyName is not null)
//                             .GroupBy(x => x.PropertyName ?? "unknown")
//                             .ToDictionary(g => g.Key, g => g.ToList())
//        };

//        return new InternalDomainProblemDetails(errors);
//    }
//}
