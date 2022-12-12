
namespace DDD.Examples.Baggage;

public record class CheckedBaggage(BaggageSize Size, decimal Weight) : BaggageItem(Size, Weight)
{
    public const int SumOfDimensions = 158;

    public override bool IsAllowedSize() => 
        BaggageSize.Minimum < Size && Size.Length + Size.Width + Size.Length < SumOfDimensions;
}
