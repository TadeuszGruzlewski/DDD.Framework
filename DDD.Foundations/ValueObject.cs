
namespace DDD.Foundations;

public abstract record class ValueObject
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    protected abstract bool LocalValidate(List<InvariantError> errors);

    public bool Validate(List<InvariantError> errors)
    {
        if (!IsValidated)
        {
            IsValid = LocalValidate(errors);
            IsValidated = true;
        }
        return (bool)IsValid!;
    }

}
