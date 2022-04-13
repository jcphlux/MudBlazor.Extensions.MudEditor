using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Utilities;
using static MudBlazor.Extensions.ToolBarAction;

namespace MudBlazor.Extensions;

public partial class MudEditor : MudComponentBase, IAsyncDisposable
{
    internal Dictionary<string, object> CurrentFormats = new();
    internal SelectionRange CurrentSelection = null!;
    private DotNetObjectReference<MudEditor>? _dotNetObjectReference;

    private IJSObjectReference? _quillEditor;

    private ElementReference _quillElement;

    private ToolBarAction _toolBarOption = null!;

    private string Classname => new CssBuilder("mud-editor").AddClass(Class).Build();

    private string ToolBarClassname =>
        new CssBuilder("mud-editor-toolbar d-flex justify-start flex-wrap gap-2 px-1 py-1").AddClass(ToolBarClass)
            .Build();

    [Inject]
    private IJSRuntime? JsRuntime { get; set; }

    [Parameter]
    public ToolBarGroup[]? ToolBarOptions { get; set; }

    [Parameter]
    public List<string> Fonts { get; set; } = null!;

    [Parameter]
    public string EditorContainerId { get; set; } = $"mudEditor{Guid.NewGuid():N}";

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public string Placeholder { get; set; } = "Compose an epic...";

    [Parameter]
    public int Elevation { get; set; } = 1;

    [Parameter]
    public bool Outlined { get; set; }

    [Parameter]
    public bool Square { get; set; }

    [Parameter]
    public string Height { get; set; } = null!;

    [Parameter]
    public string MaxHeight { get; set; } = null!;

    [Parameter]
    public string MaxWidth { get; set; } = null!;

    [Parameter]
    public string MinHeight { get; set; } = null!;

    [Parameter]
    public string MinWidth { get; set; } = null!;

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public int ToolBarElevation { get; set; } = 1;

    [Parameter]
    public bool ToolBarOutlined { get; set; }

    [Parameter]
    public string ToolBarClass { get; set; } = null!;

    [Parameter]
    public string ToolBarStyle { get; set; } = null!;

    [Parameter]
    public Color ToolBarActiveColor { get; set; } = Color.Primary;

    [Parameter]
    public Color ToolBarColor { get; set; } = Color.Inherit;

    [Parameter]
    public Variant ToolBarVariant { get; set; } = Variant.Outlined;

    public async ValueTask DisposeAsync()
    {
        if (JsRuntime != null && _dotNetObjectReference != null)
            await JsRuntime!.InvokeVoidAsync(
                "MudEditor.remove",
                _dotNetObjectReference);

        GC.SuppressFinalize(this);
    }


    internal event Action<Dictionary<string, object>> OnFormatChange = null!;

    protected override void OnParametersSet() =>
        _toolBarOption = ToolBarOptions == null ? Full : CustomToolBarOption(ToolBarOptions);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        _dotNetObjectReference = DotNetObjectReference.Create(this);
        _quillEditor = await JsRuntime!.InvokeAsync<IJSObjectReference>(
            "MudEditor.create",
            _dotNetObjectReference,
            _quillElement,
            Placeholder);
    }

    private async Task UpdateOff() => await _quillEditor!.InvokeVoidAsync("updateOff");

    private async Task UpdateOn() => await _quillEditor!.InvokeVoidAsync("updateOn");

    [JSInvokable]
    public void SetSelectionInfo(SelectionInfo selectionInfo)
    {
        CurrentSelection = selectionInfo.Range;
        Console.WriteLine("update");
        var formats = new Dictionary<string, object>();

        foreach (var (key, value) in selectionInfo.Formats)
            if (value.TryGetValue(out string? strValue))
                formats.Add(key, strValue);
            else if (value.TryGetValue(out int? intValue))
                formats.Add(key, intValue);
            else if (value.TryGetValue(out bool? boolValue))
                formats.Add(key, boolValue);

        if (CurrentFormats.Count == 0 && formats.Count == 0)
            return;

        CurrentFormats = formats;
        OnFormatChange(formats);
    }

    private async Task GetSelectionInfo()
    {
        var selectionInfo = await _quillEditor!.InvokeAsync<SelectionInfo>("getSelectionInfo");
        SetSelectionInfo(selectionInfo);
    }

    internal async Task SetAttrib(string command, string? attrib, object? value)
    {
        try
        {
            if (attrib == null)
                await _quillEditor!.InvokeVoidAsync(command, CurrentSelection.Index, CurrentSelection.Length);
            else
                await _quillEditor!.InvokeVoidAsync(command, attrib, value);
        }
        catch
        {
            // ignored This is to suppress an error coming from Quill JS Lib.
        }
        finally
        {
            await GetSelectionInfo();
        }
    }

    public record SelectionInfo(Dictionary<string, JsonValue> Formats, SelectionRange Range);

    public record SelectionRange(int Index, int Length);
}