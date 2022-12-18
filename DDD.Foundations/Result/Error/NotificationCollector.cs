namespace DDD.Foundations;

public record class NotificationCollector
{
    public IReadOnlyCollection<Error> Errors => errors;
    private readonly List<Error> errors = new();

    // TODO fieldName
    public void AddError(Error error, string? fieldName = null) => errors.Add(error);

    public bool HasErrors => errors.Count > 0;
    public int ErrorsCount => errors.Count;
}
