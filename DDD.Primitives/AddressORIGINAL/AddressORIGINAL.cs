////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using SnelStart.Diva.Errors;

//using DDD.Foundations.ValidationORIGINAL;

//namespace DDD.Primitives.AddressesORIGINAL;

//public partial record class Address : ValidationObject
//{
//    public string StreetName { get; }
//    public string StreetNumber { get; }
//    public string Affix { get; }
//    public string PostalCode { get; }
//    public string City { get; }
//    public Country Country { get; }

//    public static Address Create(string streetName,
//        string streetNumber,
//        string affix,
//        string postalCode,
//        string city,
//        Country country,
//        INotificationCollector notificationCollector = null)
//    {
//        var result = CreateWithoutValidating(streetName, streetNumber, affix, postalCode, city, country);
//        result?.Validate(notificationCollector);
//        return result;
//    }

//    public static Address CreateWithoutValidating(string streetName, string streetNumber, string affix, string postalCode, string city, Country country)
//    {
//        //return streetName == null && streetNumber == null && affix == null && postalCode == null && city == null && country == null
//        //    ? null :
//            return new (streetName, streetNumber, affix, postalCode, city, country);
//    }

//    private Address(string streetName, string streetNumber, string affix, string postalCode, string city, Country country)
//    {
//        StreetName = streetName;
//        StreetNumber = streetNumber;
//        Affix = affix;
//        PostalCode = postalCode;
//        City = city;
//        Country = country;
//    }

//    protected override IEnumerable<Func<ValidationError>> GetValidationRequirements()
//    {
//        //var conditionalValidations = new List<ConditionalAddressValidation>()
//        //{
//        //    new AddressValidationIfCountryIsNLD()
//        //}.Where(x => x.AppliesTo(this)).ToArray();

//        //if (conditionalValidations.Any())
//        //{
//        //    return conditionalValidations.SelectMany(x => x.GetValidationRequirements(this));
//        //}
//        //else
//            return new Func<ValidationError>[] { 
//                RequireStreetNameIsNotNullOrEmpty,
//                RequireStreetNumberIsPositiveInt,
//                RequirePostalCodeIsNotNullOrEmpty,
//                RequireCityIsNotNullOrEmpty,
//                RequireCountryIsValidated };
//    }

//    private abstract class ConditionalAddressValidation
//    {
//        public abstract bool AppliesTo(Address address);
//        public abstract IEnumerable<Func<ValidationError>> GetValidationRequirements(Address address);
//    }

//    protected ValidationError RequireStreetNameIsNotNullOrEmpty()
//    {
//        var errorStreetNameNullOrEmpty = new ValidationError(
//            ValidationErrorCode.NullOrEmpty,
//            $"{nameof(StreetName)} cannot be null or empty",
//            nameof(StreetName));

//        return string.IsNullOrWhiteSpace(StreetName) ? errorStreetNameNullOrEmpty : ValidationError.NoError;
//    }

//    protected ValidationError RequireStreetNumberIsPositiveInt()
//    {
//        var errorStreetNumberNullOrEmpty = new ValidationError(
//            ValidationErrorCode.NullOrEmpty,
//            $"{nameof(StreetNumber)} cannot be null or empty",
//            nameof(StreetNumber));
//        var errorStreetNumberNotNumeric = new ValidationError(
//            ValidationErrorCode.IncorrectTypeOrFormat,
//            $"{nameof(StreetNumber)} must be a positive integer number",
//            nameof(StreetNumber));

//        var errorIsNullOrEmpty = string.IsNullOrWhiteSpace(StreetNumber)
//            ? errorStreetNumberNullOrEmpty
//            : ValidationError.NoError;
//        if (errorIsNullOrEmpty != ValidationError.NoError)
//        {
//            return errorIsNullOrEmpty;
//        }

//        return (int.TryParse(StreetNumber, out var streetNumberNumeric) && streetNumberNumeric >= 0)
//            ? ValidationError.NoError
//            : errorStreetNumberNotNumeric;
//    }

//    protected ValidationError RequirePostalCodeIsNotNullOrEmpty()
//    {
//        var errorPostalCodeNullOrEmpty = new ValidationError(
//            ValidationErrorCode.NullOrEmpty,
//            $"{nameof(PostalCode)} cannot be null or empty",
//            nameof(PostalCode));

//        return string.IsNullOrWhiteSpace(PostalCode)
//            ? errorPostalCodeNullOrEmpty
//            : ValidationError.NoError;
//    }

//    protected ValidationError RequireCityIsNotNullOrEmpty()
//    {
//        var errorCityNullOrEmpty = new ValidationError(
//            ValidationErrorCode.NullOrEmpty,
//            $"{nameof(City)} cannot be null or empty",
//            nameof(City));

//        return string.IsNullOrWhiteSpace(City)
//            ? errorCityNullOrEmpty
//            : ValidationError.NoError;
//    }

//    protected ValidationError RequireCountryIsValidated()
//    {
//        var errorCountryNotValidated = new ValidationError(
//            ValidationErrorCode.ProgrammaticError,
//            $"{nameof(Country)} must be validated",
//            nameof(Country));

//        return Country.IsValidated
//                   ? ValidationError.NoError
//                   : errorCountryNotValidated;
//    }
//}

//    //protected override IEnumerable<object?> GetEqualityComponents()
//    //{
//    //    return new object?[] { StreetName, StreetNumber, Affix, PostalCode, City, Country };
//    //}

//    //public override string ToString()
//    //{
//    //    var builder = new StringBuilder();

//    //    builder.Append(StreetName);
//    //    builder.Append(' ');
//    //    builder.Append(StreetNumber);

//    //    if (!string.IsNullOrWhiteSpace(Affix))
//    //    {
//    //        builder.Append(Affix);
//    //    }

//    //    builder.Append(',');
//    //    builder.Append(' ');
//    //    builder.Append(PostalCode);
//    //    builder.Append(' ');
//    //    builder.Append(City);
//    //    builder.Append(',');
//    //    builder.Append(' ');
//    //    builder.Append(Country);

//    //    return builder.ToString().Trim();
//    //}
////}
