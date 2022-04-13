using Microsoft.AspNetCore.Components;

namespace MudBlazor.Extensions.ToolBarComponents;

public class ToolBarBase : ComponentBase, IDisposable
{
    protected bool Active;

    [Parameter]
    public MudEditor Editor { get; set; } = null!;

    [Parameter]
    public ToolBarAction Action { get; set; } = null!;

    [Parameter]
    public virtual object? Value { get; set; }

    public void Dispose()
    {
        if (!string.IsNullOrEmpty(Action.Attrib))
            Editor.OnFormatChange -= OnFormatChange;

        GC.SuppressFinalize(this);
    }

    protected override void OnParametersSet()
    {
        if (!string.IsNullOrEmpty(Action.Attrib))
            Editor.OnFormatChange += OnFormatChange;

        OnValueChanged();
    }

    private void OnFormatChange(Dictionary<string, object> formats)
    {
        if (!formats.ContainsKey(Action.Attrib))
        {
            Value = null;
            Active = false;
        }
        else
        {
            Value = formats[Action.Attrib];
            Active = Value.Equals(Action.AttribValue) || Action.Actions.Any(o => Value.Equals(o.AttribValue));
        }

        OnValueChanged();
        StateHasChanged();
    }

    protected virtual void OnValueChanged() { }
}