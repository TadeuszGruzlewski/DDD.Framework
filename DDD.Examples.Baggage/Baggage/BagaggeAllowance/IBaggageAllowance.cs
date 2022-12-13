using DDD.Foundations;

namespace DDD.Examples.Baggage;

public interface IBaggageAllowance// : IValueObject
{
    bool IsBaggageAllowed(Baggage baggage, List<InvariantError> errors);

    bool Validate()
}
