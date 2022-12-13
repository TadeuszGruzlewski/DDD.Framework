
using DDD.Foundations;

namespace DDD.Examples.Baggage;

public class BusinessBaggageAllowance : BaggageAllowance
{
    public override int AllowedNumberOfAccessories => 1;
    public override int AllowedNumberOfHandBaggages => 2;
    public override int AllowedNumberOfCheckedBaggages => 2;

    public override decimal AllowedWeightOfAllCabinBaggage => 18;
    public override decimal AllowedWeightOfOneCheckedBaggage => 32;

    public bool Validate(List<InvariantError> errors)
    {
        errors.Add(new InvariantError(InvariantErrorCode.WrongFormat, " Test "));

        return true;
    }
}
