using DDD.Foundations;

namespace DDD.Primitives.Addresses;

public abstract record class PostalCode(string Code) : ValueObject;
