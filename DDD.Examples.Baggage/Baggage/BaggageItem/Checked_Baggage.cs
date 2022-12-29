
namespace DDD.Examples.Baggage;

public record class Checked_Baggage(BaggageSize Size, decimal Weight, string Name) : BaggageItem(Size, Weight, Name)
{
    public const int SumOfDimensions = 158;

    public override bool IsAllowedSize() => 
        BaggageSize.Minimum < Size && Size.Length + Size.Width + Size.Height < SumOfDimensions;
}
