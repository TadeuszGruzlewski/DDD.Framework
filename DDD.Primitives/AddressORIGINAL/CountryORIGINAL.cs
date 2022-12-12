//using DDD.Foundations.ValidationORIGINAL;

//namespace DDD.Primitives.AddressesORIGINAL;

//public abstract record class CountryORIGINAL : ValidationObject
//{
//    protected CountryORIGINAL(string countryCode)
//    {
//        CountryCode = countryCode;
//    }

//    public string CountryCode { get; }

//    protected override IEnumerable<Func<ValidationError?>> GetValidationRequirements()
//    {
//        return new Func<ValidationError?>[] { RequireCountryCodeIsNotNullOrEmpty };
//    }

//    protected ValidationError? RequireCountryCodeIsNotNullOrEmpty()
//    {
//        const ValidationError? noError = null;
//        var errorCountryCodeNullOrEmpty = new ValidationError(
//            ValidationErrorCode.NullOrEmpty,
//            $"{nameof(CountryCode)} cannot be null or empty", 
//            nameof(CountryCode));

//        return string.IsNullOrWhiteSpace(CountryCode) 
//                ? errorCountryCodeNullOrEmpty 
//                : noError;
//    }

//    //protected override IEnumerable<object?> GetEqualityComponents()
//    //{
//    //    return new object?[] { CountryCode };
//    //}

//    //public override string ToString()
//    //{
//    //    var builder = new StringBuilder();

//    //    builder.Append(CountryCode);

//    //    return builder.ToString().Trim();
//    //}
//}
