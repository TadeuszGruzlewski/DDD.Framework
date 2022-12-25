namespace DDD.Foundations;

public interface IValidation
{
    IReadOnlyCollection<Error> Errors();

    public bool HasErrors();
    public int ErrorsCount();
}
