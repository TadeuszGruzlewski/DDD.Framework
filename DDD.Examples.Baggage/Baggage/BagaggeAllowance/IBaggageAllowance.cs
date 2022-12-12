using DDD.Foundations;

namespace DDD.Examples.Baggage;

public interface IBaggageAllowance
{
    bool IsBaggageAllowed(Baggage baggage, List<InvariantError> errors);
}
