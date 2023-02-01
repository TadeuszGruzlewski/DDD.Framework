using DDD.Foundations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality;

public sealed record User : ValueObject
{
    //   [IgnoreMember]
    public string? Name1;

    public string? Surname;

    //   [IgnoreMember]
    public string FullName => $"{Name1} {Surname}";

    public bool Equals(User? other) =>
        Name1 == other?.Name1;
        //base.Equals(other);

       public override int GetHashCode() => 1;


    protected override bool LocalValidate(NotificationCollector collector)
    {
        throw new NotImplementedException();
    }
}
