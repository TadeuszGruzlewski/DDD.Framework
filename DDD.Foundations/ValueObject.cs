
namespace DDD.Foundations;

public abstract record class ValueObject
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool AssertInvariants(List<InvariantError> errors);

    public bool Validate(List<InvariantError> errors)
    {
        if (!IsValidated)
        {
            IsValid = AssertInvariants(errors);
            IsValidated = true;
        }
        return (bool)IsValid!;
    }

}
