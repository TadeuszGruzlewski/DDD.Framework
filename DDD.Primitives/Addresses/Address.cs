using DDD.Foundations;
using System.Text;

namespace DDD.Primitives.Addresses;

public record class Address(
    string StreetName,
    string StreetNumber,
    string City,
    PostalCode PostalCode,
    Country Country) : ValueObject
{
    public override bool AssertInvariants(List<InvariantError> errors)
    {
        var invariant = new Invariant(errors);
        return invariant.IsNotNullOrEmpty(StreetName, nameof(StreetName)) &
                invariant.IsPositiveInt(StreetNumber, nameof(StreetNumber)) &
                invariant.IsNotNullOrEmpty(City, nameof(City));// &
                //invariant.IsValid(PostalCode, nameof(PostalCode)) &
                //invariant.IsValid(Country, nameof(Country));
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append(StreetName);
        builder.Append(' ');
        builder.Append(StreetNumber);

        //if (!string.IsNullOrWhiteSpace(Affix))
        //{
        //    builder.Append(Affix);
        //}

        builder.Append(',');
        builder.Append(' ');
        builder.Append(PostalCode.ToString());
        builder.Append(' ');
        builder.Append(City);
        builder.Append(',');
        builder.Append(' ');
        builder.Append(Country.ToString());

        return builder.ToString().Trim();
    }
}

//public static Address Create(string streetName,
//    string streetNumber,
//    string affix,
//    string postalCode,
//    string city,
//    Country country)
//{
//    var result = CreateWithoutValidating(streetName, streetNumber, affix, postalCode, city, country);
//    result?.Validate(notificationCollector);
//    return result;
//}

//public static Address CreateWithoutValidating(string streetName, string streetNumber, string affix, string postalCode, string city, Country country)
//{
//        return new (streetName, streetNumber, affix, postalCode, city, country);
//}

//private Address(string streetName, string streetNumber, string affix, string postalCode, string city, Country country)
//{
//    StreetName = streetName;
//    StreetNumber = streetNumber;
//    Affix = affix;
//    PostalCode = postalCode;
//    City = city;
//    Country = country;
//}

//protected override IEnumerable<Func<ValidationError>> GetValidationRequirements()
//{
//    //var conditionalValidations = new List<ConditionalAddressValidation>()
//    //{
//    //    new AddressValidationIfCountryIsNLD()
//    //}.Where(x => x.AppliesTo(this)).ToArray();

//    //if (conditionalValidations.Any())
//    //{
//    //    return conditionalValidations.SelectMany(x => x.GetValidationRequirements(this));
//    //}
//    //else
//        return new Func<ValidationError>[] { 
//            RequireStreetNameIsNotNullOrEmpty,
//            RequireStreetNumberIsPositiveInt,
//            RequirePostalCodeIsNotNullOrEmpty,
//            RequireCityIsNotNullOrEmpty,
//            RequireCountryIsValidated };
//}

//private abstract class ConditionalAddressValidation
//{
//    public abstract bool AppliesTo(Address address);
//    public abstract IEnumerable<Func<ValidationError>> GetValidationRequirements(Address address);
//}


//protected override IEnumerable<object?> GetEqualityComponents()
//{
//    return new object?[] { StreetName, StreetNumber, Affix, PostalCode, City, Country };
//}

//public override string ToString()
//{
//    var builder = new StringBuilder();

//    builder.Append(StreetName);
//    builder.Append(' ');
//    builder.Append(StreetNumber);

//    if (!string.IsNullOrWhiteSpace(Affix))
//    {
//        builder.Append(Affix);
//    }

//    builder.Append(',');
//    builder.Append(' ');
//    builder.Append(PostalCode);
//    builder.Append(' ');
//    builder.Append(City);
//    builder.Append(',');
//    builder.Append(' ');
//    builder.Append(Country);

//    return builder.ToString().Trim();
//}
//}
