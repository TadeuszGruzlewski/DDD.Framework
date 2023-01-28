
namespace DDD.Examples.Baggage;

public record class BusinessBaggageAllowance : BaggageAllowance
{
    public override int NumberOfAccessories => 1;
    public override int NumberOfHandItems => 2;
    public override int NumberOfCheckedItems => 2;

    public override Weight WeightOfAllCabinBaggage => new(18);
    public override Weight WeightOfOneCheckedBaggage => new(32);
}
