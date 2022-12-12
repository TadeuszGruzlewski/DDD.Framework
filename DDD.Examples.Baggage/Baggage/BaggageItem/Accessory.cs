
namespace DDD.Examples.Baggage;

public record class Accessory(BaggageSize Size, decimal Weight) : BaggageItem(Size, Weight)
{
    public static readonly BaggageSize MaxSize = new(40, 30, 15);

    public override bool IsAllowedSize() => BaggageSize.Minimum < Size && Size < MaxSize;
}
