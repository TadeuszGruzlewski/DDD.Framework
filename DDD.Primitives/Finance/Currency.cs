using DDD.Foundations;

namespace DDD.Primitives.Finance;

public record class Currency : Enumeration
{
    public int NumericCode => Id;
    public string? Entity => Name;
    public string? AlphaCode { get; init; }
    public string? Symbol { get; init; }

    private Currency(int numericCode, string entity, string alphaCode, string symbol) :
        base(numericCode, entity) => (AlphaCode, Symbol) = (alphaCode, symbol);

    public static readonly Currency Euro = new(978, "Euro", "EUR", "€");
    public static readonly Currency USD = new(840, "United States dollar", "USD", "$");
    // TODO other currencies
}
