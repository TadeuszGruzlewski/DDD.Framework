
namespace DDD.Examples.Baggage;

public record class HandBaggage(BaggageSize Size, decimal Weight) : BaggageItem(Size, Weight)
{
    public static readonly BaggageSize MaxSize = new(55, 35, 25);

    public override bool IsAllowedSize() => BaggageSize.Minimum < Size && Size < MaxSize;
}
