//namespace DDD.Foundations.ValidationORIGINAL;

///// <summary>
///// Class for formatting the errors in global and field domain errors
///// </summary>
//public record class Errors<T> where T : IDomainErrorModel
//{
//    /// <summary>
//    /// List of domain validation errors not mappable to specific entity properties
//    /// </summary>
//    public List<T> Global { get; set; }

//    /// <summary>
//    /// List of domain validation errors mappable to specific entity properties
//    /// </summary>
//    public Dictionary<string, List<T>> Field { get; set; }
//}
