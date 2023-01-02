
namespace DDD.Examples.Baggage;

public record class HandBaggage(BaggageSize Size, decimal Weight, string Name) : BaggageItem(Size, Weight, Name)
{
    public static readonly BaggageSize MaxSize = new(55, 35, 25);

    public override bool IsAllowedSize() => BaggageSize.Minimum < Size && Size < MaxSize;
}
