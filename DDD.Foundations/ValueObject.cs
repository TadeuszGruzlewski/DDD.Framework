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




    // This part will be used in future auto validation of VO
    //public void Validate<T>(List<InvariantError> errors) where T : ValueObject
    //{
    //    var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.FlattenHierarchy;
    //    var z = BindingFlags.NonPublic | BindingFlags.Instance;
    //    var f0 = typeof(T).GetFields();
    //    var z0 = typeof(T).GetMethods();
    //    var z1 = typeof(T).GetMembers(z);

    //    var z2 = typeof(T).FindMembers(MemberTypes.Field, flags, null, null);
    //}

}
