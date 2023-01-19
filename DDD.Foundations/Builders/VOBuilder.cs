
namespace DDD.Foundations;

public abstract class VOBuilder<VO> : IVOBuilder<VO> where VO : ValueObject//, new()
{
    protected VO? valueObject;

    public VOBuilder(string valueObjectName) =>
        //   valueObject = new VO("a");
        //   valueObject = (VO?)Activator.CreateInstance(typeof(VO), BindingFlags.NonPublic, new object[] { valueObjectName });
        valueObject = (VO?)Activator.CreateInstance(typeof(VO), new object[] { valueObjectName });

    public NotificationCollector NotificationCollector { get; } = new();

    public VO? Build()
    {
        valueObject?.Validate(NotificationCollector, valueObject.Name!);
        return NotificationCollector.HasErrors ? null : valueObject;
    }
}
