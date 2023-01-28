
namespace DDD.Examples.Baggage;

public record class EconomyBaggageAllowance : BaggageAllowance
{
    public override int NumberOfAccessories => 1;
    public override int NumberOfHandItems => 1;
    public override int NumberOfCheckedItems => 1;

    public override Weight WeightOfAllCabinBaggage => new(12);
    public override Weight WeightOfOneCheckedBaggage => new(23);
}
