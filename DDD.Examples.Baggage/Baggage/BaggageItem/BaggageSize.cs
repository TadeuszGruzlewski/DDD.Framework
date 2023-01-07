
namespace DDD.Examples.Baggage;

public record class BaggageSize(int Length, int Width, int Height)
{
    public static readonly BaggageSize Minimum = new(0, 0, 0);

    public static bool operator <=(BaggageSize s1, BaggageSize s2) =>
        s1.Length <= s2.Length & s1.Width <= s2.Width & s1.Height <= s2.Height;
    public static bool operator >=(BaggageSize s1, BaggageSize s2) => !(s1 <= s2);

    public static bool operator <=(BaggageSize s, decimal sum) =>
        s.Length + s.Width + s.Height <= sum;
    public static bool operator >=(BaggageSize s, decimal sum) => !(s <= sum);
}
