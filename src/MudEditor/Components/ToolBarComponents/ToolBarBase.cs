using Microsoft.AspNetCore.Components;

namespace MudBlazor.Extensions.ToolBarComponents;

public class ToolBarBase : ComponentBase, IDisposable
{
    protected bool Active;
    protected Color ActiveColor = Color.Primary;
    protected Color Color = Color.Default;

    [CascadingParameter]
    public MudEditor Editor { get; set; } = null!;

    [CascadingParameter]
    public ToolBarOption Option { get; set; } = null!;

    [Parameter]
    public virtual object? Value { get; set; }


    public void Dispose()
    {
        if (!string.IsNullOrEmpty(Option.Attrib) || Option.AllowNull)
            Editor.OnFormatChange -= OnFormatChange;
    }

    protected override void OnParametersSet()
    {
        Color = Editor.ToolBarColor;
        ActiveColor = Editor.ToolBarActiveColor;
        if (!string.IsNullOrEmpty(Option.Attrib) || Option.AllowNull)
            Editor.OnFormatChange += OnFormatChange;

        OnValueChanged();
    }

    private void OnFormatChange(Dictionary<string, object> formats)
    {
        if (!formats.ContainsKey(Option.Attrib))
        {
            Value = null;
            Active = false;
        }
        else
        {
            Value = formats[Option.Attrib];
            Active = Value.Equals(Option.AttribValue) || Option.Options.Any(o => Value.Equals(o.AttribValue));
        }

        OnValueChanged();
        StateHasChanged();
    }

    protected virtual void OnValueChanged() { }
}