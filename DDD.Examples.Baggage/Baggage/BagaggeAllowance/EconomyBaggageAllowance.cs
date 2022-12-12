

namespace DDD.Examples.Baggage;

public class EconomyBaggageAllowance : BaggageAllowance
{
    public override int AllowedNumberOfAccessories => 1;
    public override int AllowedNumberOfHandBaggages => 1;
    public override int AllowedNumberOfCheckedBaggages => 1;

    public override decimal AllowedWeightOfAllCabinBaggage => 12;
    public override decimal AllowedWeightOfOneCheckedBaggage => 23;
}
