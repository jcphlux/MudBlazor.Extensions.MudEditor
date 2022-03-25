using Microsoft.AspNetCore.Components;
using MudBlazor.Extensions.Settings;

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
    public virtual ToolBarValue Value { get; set; } = new();


    public void Dispose()
    {
        if (!string.IsNullOrEmpty(Option.Attrib) || Option.AllowNull)
            Editor.OnFormatChange -= OnFormatChange;
    }

    protected override void OnParametersSet()
    {
        Value = new();
        Color = Editor.ToolBarColor;
        ActiveColor = Editor.ToolBarActiveColor;
        if (!string.IsNullOrEmpty(Option.Attrib) || Option.AllowNull)
            Editor.OnFormatChange += OnFormatChange;
    }

    private void OnFormatChange(Dictionary<string, ToolBarValue> formats)
    {
        if (!formats.ContainsKey(Option.Attrib) || Option.AttribValue == null && !Option.AllowNull)
        {
            Value.Clear();
            Active = false;
        }
        else
        {
            Value = formats[Option.Attrib];
            Active = Value.IsActive(Option.AttribValue);
        }

        OnValueChanged();
        StateHasChanged();
    }

    protected virtual void OnValueChanged() { }
}