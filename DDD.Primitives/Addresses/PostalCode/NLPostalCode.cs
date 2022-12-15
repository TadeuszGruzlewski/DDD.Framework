using DDD.Foundations;

namespace DDD.Primitives.Addresses;

public record class NlPostalCode(string Code) : PostalCode(Code)
{
    protected override bool LocalValidate(List<InvariantError> errors) =>
        new Invariant(errors).IsCorrectFormat(new("[0-9]{4}[A-Za-z]{2}$"), Code, nameof(Code));
}
