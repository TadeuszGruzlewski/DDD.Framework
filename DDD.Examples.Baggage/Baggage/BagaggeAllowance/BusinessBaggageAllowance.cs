
namespace DDD.Examples.Baggage;

public record class BusinessBaggageAllowance : BaggageAllowance
{
    public override int NumberOfAccessories => 1;
    public override int NumberOfHandBaggages => 2;
    public override int NumberOfCheckedBaggages => 2;

    public override decimal WeightOfAllCabinBaggage => 18;
    public override decimal WeightOfOneCheckedBaggage => 32;
}
