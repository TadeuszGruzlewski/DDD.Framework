using System.Reflection;
using System.Runtime.CompilerServices;

namespace DDD.Foundations;

public abstract record class ValueObject
{
    public bool IsValidated { get; private set; } = false;
    public bool? IsValid { get; private set; } = null;

    public abstract bool AssertInvariants(List<InvariantError> errors);

    public void Validate(List<InvariantError> errors)
    {
        if (IsValidated)
            return;

        IsValid = AssertInvariants(errors);
        IsValidated = true;
    }





    public void Validate<T>(List<InvariantError> errors) where T : ValueObject
    {
        var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy;
        var z = BindingFlags.NonPublic | BindingFlags.Instance;
                var f = typeof(T).GetFields(z);
        foreach(var ff in f)
        {

            if(ff.FieldType.IsGenericType && ff.FieldType.GetGenericTypeDefinition() == typeof(List<>) 
                && typeof(ValueObject).IsAssignableFrom(ff.FieldType.GetGenericArguments()[0]))
            {
                var list = ff.GetValue(this) as IEnumerable<ValueObject>;
                list.ToList().First().Validate(errors);
                var m = ff.FieldType.GetMethod("Validate");
                m?.Invoke(ff.GetValue(this), new[] { errors});
            }
        }

  //      var f0 = typeof(T).GetFields(flags);

        var z0 = typeof(T).GetMethods();
        var z1 = typeof(T).GetMembers(z);

        var z2 = typeof(T).FindMembers(MemberTypes.Field, flags, null, null);
    }

}
