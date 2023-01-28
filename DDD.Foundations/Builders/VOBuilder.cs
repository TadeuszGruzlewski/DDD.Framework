
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject
{
    protected VO Root;

    public NotificationCollector NotificationCollector { get; } = new();

    public VOBuilder(string rootName) => Root = CreateRoot(rootName);

    protected abstract VO CreateRoot(string rootName);

    public VO? Build()
    {
        Root.Validate(NotificationCollector);
        return NotificationCollector.HasErrors ? null : Root;
    }
}
