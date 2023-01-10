

using DDD.Primitives.Measures;

namespace DDD.Examples.Baggage;

public record class EconomyBaggageAllowance : BaggageAllowance
{
    public override int NumberOfAccessories => 1;
    public override int NumberOfHandBaggages => 1;
    public override int NumberOfCheckedBaggages => 1;

    public override Weight WeightOfAllCabinBaggage => new Weight(12);
    public override Weight WeightOfOneCheckedBaggage => new Weight(23);
}
