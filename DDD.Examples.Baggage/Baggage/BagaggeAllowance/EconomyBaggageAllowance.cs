

namespace DDD.Examples.Baggage;

public record class EconomyBaggageAllowance : BaggageAllowance
{
    public override int NumberOfAccessories => 1;
    public override int NumberOfHandBaggages => 1;
    public override int NumberOfCheckedBaggages => 1;

    public override decimal WeightOfAllCabinBaggage => 12;
    public override decimal WeightOfOneCheckedBaggage => 23;
}
