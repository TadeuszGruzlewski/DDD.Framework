
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO? ValueObject;
    public VOBuilder() =>
        ValueObject = (VO?)Activator.CreateInstance(typeof(VO), true);

    //public IReadOnlyCollection<InvariantError> Errors => errors;
    //private readonly List<InvariantError> errors = new();

    public readonly NotificationCollector Collector = new();

    public VO? Build()
    {
        ValueObject?.Validate(Collector);
        return Collector.HasErrors ? null : ValueObject;
    }
}
