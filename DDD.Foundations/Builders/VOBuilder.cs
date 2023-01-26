
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO Root;

    public NotificationCollector NotificationCollector { get; } = new();

    public VOBuilder(string rootName) =>
        Root = Create(rootName);

    protected abstract VO Create(string rootName);

    public VO? Build()
    {
        Root.Validate(NotificationCollector);
        return NotificationCollector.HasErrors ? null : Root;
    }
}
