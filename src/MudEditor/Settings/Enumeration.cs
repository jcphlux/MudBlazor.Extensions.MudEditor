using System.Reflection;

namespace MudBlazor.Extensions.Settings;

public abstract class Enumeration : IComparable
{
    protected Enumeration(int? value, string name)
    {
        Value = value ?? GetAll<Enumeration>().Count();
        Name = name;
    }

    public string Name { get; }

    public int Value { get; }

    public int CompareTo(object? other) => Value.CompareTo(((Enumeration) other!).Value);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var fields = typeof(T).GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Enumeration otherValue))
            return false;

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue) =>
        Math.Abs(firstValue.Value - secondValue.Value);

    public static bool TryGetFromValueOrName<T>(
        string valueOrName,
        out T? enumeration)
        where T : Enumeration
    {
        return TryParse(item => item!.Name == valueOrName, out enumeration) ||
               int.TryParse(valueOrName, out var value) &&
               TryParse(item => item!.Value == value, out enumeration);
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        return Parse<T, int>(value, "nameOrValue", item => item.Value == value);
    }

    public static T FromName<T>(string name) where T : Enumeration
    {
        return Parse<T, string>(name, "name", item => item.Name == name);
    }

    private static bool TryParse<TEnumeration>(
        Func<TEnumeration?, bool> predicate,
        out TEnumeration? enumeration)
        where TEnumeration : Enumeration
    {
        enumeration = GetAll<TEnumeration>().FirstOrDefault(predicate);
        return enumeration != null;
    }

    private static TEnumeration Parse<TEnumeration, TIntOrString>(
        TIntOrString nameOrValue,
        string description,
        Func<TEnumeration, bool> predicate)
        where TEnumeration : Enumeration
    {
        var matchingItem = GetAll<TEnumeration>().FirstOrDefault(predicate);

        if (matchingItem == null)
            throw new InvalidOperationException(
                $"'{nameOrValue}' is not a valid {description} in {typeof(TEnumeration)}");

        return matchingItem;
    }
}