using System.Text.Json.Nodes;

namespace MudBlazor.Extensions.Settings;

public class ToolBarValue
{
    public ToolBarValue(string strValue = null!, int? intValue = null, bool? boolValue = null)
    {
        StrValue = strValue;
        IntValue = intValue;
        BoolValue = boolValue;
    }

    public string StrValue { get; set; }
    public int? IntValue { get; set; }
    public bool? BoolValue { get; set; }

    public static ToolBarValue FromJson(JsonValue value)
    {
        value.TryGetValue(out string? strValue);
        value.TryGetValue(out int? intValue);
        value.TryGetValue(out bool? boolValue);
        return new(strValue!, intValue, boolValue);
    }

    public bool IsActive(object? attribValue)
    {
        if (attribValue is string)
            return attribValue.Equals(StrValue);
        if (attribValue is int)
            return attribValue.Equals(IntValue);
        return attribValue is bool && attribValue.Equals(BoolValue);
    }

    public object? Toggle(object? attribValue)
    {
        if (attribValue is string)
            return attribValue.Equals(StrValue) ? null : attribValue;
        if (attribValue is int)
            return attribValue.Equals(IntValue) ? null : attribValue;
        return attribValue is bool && !attribValue.Equals(BoolValue);
    }

    public void Clear()
    {
        StrValue = null!;
        IntValue = null!;
        BoolValue = null!;
    }
}