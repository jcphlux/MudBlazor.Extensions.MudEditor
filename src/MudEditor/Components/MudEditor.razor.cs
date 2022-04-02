﻿using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Utilities;
using static MudBlazor.Extensions.ToolBarOption;

namespace MudBlazor.Extensions;

public partial class MudEditor : MudComponentBase, IAsyncDisposable
{
    private DotNetObjectReference<MudEditor>? _dotNetObjectReference;

    private IJSObjectReference? _quillEditor;

    private ElementReference _quillElement;

    private ToolBarOption _toolBarOption = null!;

    private string Classname => new CssBuilder("mud-editor").AddClass(Class).Build();

    private string ToolBarClassname => new CssBuilder("mud-editor-toolbar d-flex justify-start flex-wrap gap-2 px-1 py-1").AddClass(ToolBarClass).Build();

    [Inject]
    private IJSRuntime? JsRuntime { get; set; }

    [Parameter]
    public ToolBarGroup[] ToolBarOptions { get; set; } = null!;

    [Parameter]
    public List<string> Fonts { get; set; } = null!;

    [Parameter]
    public string EditorContainerId { get; set; } = null!;

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

    //[Parameter]
    //public Color ToolBarBackgroundColor { get; set; } = Color.Surface;

    [Parameter]
    public Variant ToolBarVariant { get; set; } = Variant.Outlined;

    public async ValueTask DisposeAsync()
    {
        if (JsRuntime != null && _dotNetObjectReference != null)
            await JsRuntime!.InvokeVoidAsync(
                "MudEditor.remove",
                _dotNetObjectReference,
                _quillElement,
                Placeholder);
    }

    internal event Action<Dictionary<string, object>> OnFormatChange = null!;

    protected override void OnParametersSet()
    {
        _toolBarOption = ToolBarOptions == null ? Full : CustomToolBarOption(ToolBarOptions);
    }

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

    [JSInvokable]
    public void QuillGetFormat(Dictionary<string, JsonValue> jsonFormats)
    {
        var formats = new Dictionary<string, object>();

        foreach (var (key, value) in jsonFormats)
            if (value.TryGetValue(out string? strValue))
                formats.Add(key, strValue);
            else if (value.TryGetValue(out int? intValue))
                formats.Add(key, intValue);
            else if (value.TryGetValue(out bool? boolValue))
                formats.Add(key, boolValue);

        OnFormatChange(formats);
    }

    internal async Task SetFormat(string attrib, object? value) =>
        await _quillEditor!.InvokeVoidAsync("format", attrib, value);
}