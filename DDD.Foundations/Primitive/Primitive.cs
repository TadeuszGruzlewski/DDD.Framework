namespace DDD.Foundations;

public abstract record class Primitive
{
    public string ErrorMsg { get; set; } = string.Empty;

    public abstract bool IsValid();

    protected Primitive()
    {
        if (!IsValid())
            throw new ArgumentException(ErrorMsg);
    }

    //not thread safe in this form
    //requires critical section
    //private static bool allowCopy = false;
    //protected static void AllowCopy() => allowCopy = true;

    protected Primitive(Primitive? _)
    {
        //if (allowCopy)
        //    return;
        //allowCopy = false;
        //if (!IsValid())
        //    throw new ArgumentException(ErrorMsg);
        var msg = "'with' operator is not allowed.";
        throw new InvalidOperationException(msg);
    }

    protected static Primitive? Create(Type type, params object[] args)
    {
        var q = (Primitive?)Activator.CreateInstance(type, args);
        // Activator is not using a primary constructor. We enforce validation.
        if (q!.IsValid())
            return q;
        throw new ArgumentException(q.ErrorMsg);
    }
}
