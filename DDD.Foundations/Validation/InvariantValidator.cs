using System.Text.RegularExpressions;

namespace DDD.Foundations;

public record class InvariantValidator(NotificationCollector Collector)
{
    protected void AddError(InvariantErrorCode code, string name, string? details = null) =>
        Collector.AddError(code, name, details);

    public bool IsNotNullArgument(object? obj, string name)
    {
        var valid = obj is not null;
        if (!valid)
            AddError(InvariantErrorCode.NullArgument, name);
        return valid;
    }

    public bool IsNotNullReference(object? obj, string name)
    {
        var valid = obj is not null;
        if (!valid)
            AddError(InvariantErrorCode.NullReference, name);
        return valid;
    }

    public bool IsNotNullOrEmpty(string field, string name)
    {
        var valid = !string.IsNullOrWhiteSpace(field);
        if (!valid)
            AddError(InvariantErrorCode.NullOrEmpty, name);
        return valid;
    }

    public bool IsPositive(int field, string name)
    {
        var valid = field > 0;
        if (!valid)
            AddError(InvariantErrorCode.BelowMinimum, name, "Must be positive");
        return valid;
    }

    public bool IsPositive(string field, string name)
    {
        var valid1 = string.IsNullOrWhiteSpace(field);
        if (!valid1)
            AddError(InvariantErrorCode.NullOrEmpty, name);
        var valid2 = int.TryParse(field, out var number) && number >= 0;
        if (!valid2)
            AddError(InvariantErrorCode.BelowMinimum, name, "Must be positive");
        return valid1 && valid2;
    }

    //public static bool IsCorrectFormat(Regex regex, string field, string name)
    //{
    //    var valid = regex.IsMatch(field);
    //    if (!valid)
    //        AddError(InvariantErrorCode.WrongType, name);
    //    return valid;
    //}

    public bool IsAboveMinimum(Regex regex, string field, string name, decimal minimum)
    {
        var valid = regex.IsMatch(field);
        if (!valid)
            AddError(InvariantErrorCode.BelowMinimum, name, $"Must be above {minimum}");       
        return valid;
    }

    public bool IsBelowMaximum(Regex regex, string field, string name, decimal maximum)
    {
        var valid = regex.IsMatch(field);
        if (!valid)
            AddError(InvariantErrorCode.AboveMaximum, name, $"Must be below {maximum}");
        return valid;
    }

    //public static bool IsValid(ValueObject valueObject, string name)
    //{
    //    var valid = valueObject.IsValid;
    //    if (!valid)
    //        Errors.Add(new(InvariantErrorCode.ProgrammaticError, $"{name} is invalid", name));
    //    return valid;
    //}

    //public static bool IsValid(Entity entity, string name)
    //{
    //    var valid = entity.IsValid;
    //    if (!valid)
    //        Errors.Add(new(InvariantErrorCode.ProgrammaticError, $"{name} is invalid", name));
    //    return valid;
    //}
}
