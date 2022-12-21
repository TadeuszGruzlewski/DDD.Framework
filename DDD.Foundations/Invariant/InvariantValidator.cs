using System.Text.RegularExpressions;

namespace DDD.Foundations;

public record class InvariantValidator(NotificationCollector Collector)
{
    protected void AddError(InvariantErrorCode errorCode, string errorMessage, string fieldName) 
        => Collector.AddError(new InvariantError(errorCode, errorMessage, Collector.Context + " >>> " + fieldName));
            //=> Collector.AddError(new InvariantError(errorCode, errorMessage, fieldName));

    public bool IsNotNullArgument(object? obj, string name)
    {
        var valid = obj is not null;
        if (!valid)
            AddError(InvariantErrorCode.NullArgument, $"{name} cannot be null", name);
        return valid;
    }

    public bool IsNotNullReference(object? obj, string name)
    {
        var valid = obj is not null;
        if (!valid)
            AddError(InvariantErrorCode.NullReference, $"{name} cannot be null", name);
        return valid;
    }

    public bool IsNotNullOrEmpty(string field, string name)
    {
        var valid = !string.IsNullOrWhiteSpace(field);
        if (!valid)
            AddError(InvariantErrorCode.NullOrEmpty, $"{name} cannot be null or empty", name);
        return valid;
    }

    public bool IsPositiveInt(int field, string name)
    {
        var valid = field > 0;
        if (!valid)
            AddError(InvariantErrorCode.WrongType, $"{name} must be a positive integer number", name);
        return valid;
    }

    public bool IsPositiveInt(string field, string name)
    {
        var valid1 = string.IsNullOrWhiteSpace(field);
        if (!valid1)
            AddError(InvariantErrorCode.NullOrEmpty, $"{name} cannot be null or empty", name);
        var valid2 = int.TryParse(field, out var number) && number >= 0;
        if (!valid2)
            AddError(InvariantErrorCode.WrongType, $"{name} must be a positive integer number", name);
        return valid1 && valid2;
    }

    public bool IsCorrectFormat(Regex regex, string field, string name)
    {
        var valid = regex.IsMatch(field);
        if (!valid)
            AddError(InvariantErrorCode.WrongType, $"{name} must be a positive integer number", name);
        return valid;
    }

    public bool IsAboveMinimum(Regex regex, string field, string name, decimal minimum)
    {
        var valid = regex.IsMatch(field);
        if (!valid)
            AddError(InvariantErrorCode.BelowMinimum, $"{name} must be above {minimum}", name);
        return valid;
    }

    public bool IsBelowMaximum(Regex regex, string field, string name, decimal maximum)
    {
        var valid = regex.IsMatch(field);
        if (!valid)
            AddError(InvariantErrorCode.AboveMaximum, $"{name} must be below {maximum}", name);
        return valid;
    }

    //public bool IsValid(ValueObject valueObject, string name)
    //{
    //    var valid = valueObject.IsValid;
    //    if (!valid)
    //        Errors.Add(new(InvariantErrorCode.ProgrammaticError, $"{name} is invalid", name));
    //    return valid;
    //}

    //public bool IsValid(Entity entity, string name)
    //{
    //    var valid = entity.IsValid;
    //    if (!valid)
    //        Errors.Add(new(InvariantErrorCode.ProgrammaticError, $"{name} is invalid", name));
    //    return valid;
    //}
}
