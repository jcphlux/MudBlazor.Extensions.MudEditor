using System.Runtime.CompilerServices;
using MudBlazor.Extensions.ToolBarComponents;

namespace MudBlazor.Extensions.Settings;

public class ToolBarGroupType : Enumeration
{
    internal static readonly ToolBarGroupType Expanded = new(typeof(ToolBarExpanded));
    internal static readonly ToolBarGroupType Menu = new(typeof(ToolBarMenu));
    internal static readonly ToolBarGroupType Toggle = new(typeof(ToolBarToggle));
    internal static readonly ToolBarGroupType List = new(typeof(ToolBarList));
    internal static readonly ToolBarGroupType Group = new(typeof(ToolBarBtnGroup));
    internal static readonly ToolBarGroupType Btn = new(typeof(ToolBarBtn));
    internal static readonly ToolBarGroupType ColorPicker = new(typeof(ToolBarColorPicker));
    internal static readonly ToolBarGroupType UrlDialog = new(typeof(ToolBarUrl));
    internal static readonly ToolBarGroupType File = new(typeof(ToolBarUrl));
    internal static readonly ToolBarGroupType ToolBarBase = new(value: 7);

    private ToolBarGroupType(Type componentType = null!, int? value = null, [CallerMemberName] string name = null!) :
        base(value, name) =>
        ComponentType = componentType;

    public Type ComponentType { get; }
}