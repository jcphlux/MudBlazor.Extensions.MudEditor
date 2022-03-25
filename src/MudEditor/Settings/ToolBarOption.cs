using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MudBlazor.Extensions.CustomIcons;
using MudBlazor.Extensions.Settings;
using static MudBlazor.Extensions.Settings.ToolBarGroupType;

namespace MudBlazor.Extensions;

public class ToolBarOption : Enumeration
{
    public static readonly ToolBarOption FontList = new(List, "font", allowNull: true);

    public static readonly ToolBarOption SizeList = new(List, "size", allowNull: true);

    public static readonly ToolBarOption BoldStyle = new(Btn, "bold", "Bold", Icons.Filled.FormatBold, true);
    public static readonly ToolBarOption ItalicStyle = new(Btn, "italic", "Italic", Icons.Filled.FormatItalic, true);

    public static readonly ToolBarOption UnderlineStyle =
        new(Btn, "underline", "Underline", Icons.Filled.FormatUnderlined, true);

    public static readonly ToolBarOption StrikethroughStyle =
        new(Btn, "strike", "Strikethrough", Icons.Filled.FormatStrikethrough, true);

    public static readonly ToolBarOption StyleGroup = new(Group,
        options: new[] {BoldStyle, ItalicStyle, UnderlineStyle, StrikethroughStyle});

    public static readonly ToolBarOption FontColor = new(ColorPicker, "color", "Font Color",
        Icons.Filled.FormatColorText, allowNull: true);

    public static readonly ToolBarOption BackgroundColor =
        new(ColorPicker, "background", "Background Color", Icons.Filled.FontDownload, allowNull: true);

    public static readonly ToolBarOption ColorGroup = new(Group, options: new[] {FontColor, BackgroundColor});

    public static readonly ToolBarOption Heading1 = new(Btn, "header", "H1", MudEditorIcons.Icons.H1, 1);
    public static readonly ToolBarOption Heading2 = new(Btn, "header", "H2", MudEditorIcons.Icons.H2, 2);
    public static readonly ToolBarOption Heading3 = new(Btn, "header", "H3", MudEditorIcons.Icons.H3, 3);
    public static readonly ToolBarOption Heading4 = new(Btn, "header", "H4", MudEditorIcons.Icons.H4, 4);
    public static readonly ToolBarOption Heading5 = new(Btn, "header", "H5", MudEditorIcons.Icons.H5, 5);
    public static readonly ToolBarOption Heading6 = new(Btn, "header", "H6", MudEditorIcons.Icons.H6, 6);

    public static readonly ToolBarOption HeadingMenu =
        new(Menu, "header", options: new[] {Heading1, Heading2, Heading3, Heading4, Heading5, Heading6},
            allowNull: true);

    public static readonly ToolBarOption HeadingExpanded = new(Expanded, "header",
        options: new[] {Heading1, Heading2, Heading3, Heading4, Heading5, Heading6}, allowNull: true);

    public static readonly ToolBarOption Quote = new(Btn, "blockquote", "Quote", Icons.Filled.FormatQuote, true);

    public static readonly ToolBarOption Code = new(Btn, "code-block", "Code", Icons.Filled.Code, true);

    public static readonly ToolBarOption ListNumbered =
        new(Btn, "list", "Numbered List", Icons.Filled.FormatListNumbered, "ordered");

    public static readonly ToolBarOption ListBulleted =
        new(Btn, "list", "Bulleted List", Icons.Filled.FormatListBulleted, "bullet");

    public static readonly ToolBarOption ListGroup = new(Group, "list", options: new[]
        {ListNumbered, ListBulleted}, allowNull: true);

    public static readonly ToolBarOption IndentIncrease =
        new(Btn, "indent", "Increase Indent", Icons.Filled.FormatIndentIncrease, 1);

    public static readonly ToolBarOption IndentDecrease =
        new(Btn, "indent", "Decrease Indent", Icons.Filled.FormatIndentDecrease, -1);


    public static readonly ToolBarOption IndentGroup = new(Group, options: new[] {IndentIncrease, IndentDecrease});

    public static readonly ToolBarOption AlignLeft = new(Btn, "align", "Align Left", Icons.Filled.FormatAlignLeft,
        allowNull: true);

    public static readonly ToolBarOption AlignCenter = new(Btn, "align", "Align Center", Icons.Filled.FormatAlignCenter,
        "center");

    public static readonly ToolBarOption AlignRight = new(Btn, "align", "Align Right", Icons.Filled.FormatAlignRight,
        "right");

    public static readonly ToolBarOption AlignJustify =
        new(Btn, "align", "Justify", Icons.Filled.FormatAlignJustify, "justify");

    public static readonly ToolBarOption AlignmentMenu =
        new(Menu, "align", options: new[] {AlignLeft, AlignCenter, AlignRight, AlignJustify}, allowNull: true);

    public static readonly ToolBarOption AlignmentExpanded =
        new(Expanded, "align", options: new[] {AlignLeft, AlignCenter, AlignRight, AlignJustify}, allowNull: true);

    internal static readonly ToolBarOption
        Ltr = new(Btn, "direction", "Left to Right", Icons.Filled.FormatTextdirectionLToR, allowNull: true);

    internal static readonly ToolBarOption
        Rtl = new(Btn, "direction", "Right to Left", Icons.Filled.FormatTextdirectionRToL, "rtl");

    public static readonly ToolBarOption LtrToggle = new(Toggle, "direction", options: new[] {Ltr, Rtl},
        allowNull: true);

    public static readonly ToolBarOption LrtExpanded = new(Expanded, "direction", options: new[] {Ltr, Rtl},
        allowNull: true);

    public static readonly ToolBarOption Link = new(Btn, "link", "Embed Link", Icons.Filled.InsertLink);
    public static readonly ToolBarOption Image = new(Btn, "image", "Embed Image", Icons.Filled.Image);
    public static readonly ToolBarOption Video = new(Btn, "video", "Embed Video", Icons.Filled.OndemandVideo);

    public static readonly ToolBarOption MediaGroup = new(Group, options: new[] {Link, Image, Video});

    public static readonly ToolBarOption Formula = new(Btn, "formula", "Formula", MudEditorIcons.Icons.Fx);
    public static readonly ToolBarOption Subscript = new(Btn, "script", "Subscript", Icons.Filled.Subscript, "sub");

    public static readonly ToolBarOption Superscript = new(Btn, "script", "Superscript", Icons.Filled.Superscript,
        "super");

    public static readonly ToolBarOption MathGroup = new(Group, options: new[] {Formula, Subscript, Superscript});

    public static readonly ToolBarOption FormatClear = new(Btn, "clear", "Clear Format", Icons.Filled.FormatClear);

    internal static readonly ToolBarOption Full =
        new(ToolBarBase,
            options: new[]
            {
                FontList, SizeList, StyleGroup,
                ColorGroup, HeadingMenu, Quote,
                Code, ListGroup, IndentGroup,
                AlignmentMenu, LtrToggle, MediaGroup,
                MathGroup, FormatClear
            });

    private ToolBarOption(ToolBarGroupType type, string attrib = null!, string? label = null,
        string icon = null!, object? attribValue = null, ToolBarOption[]? options = null, bool allowNull = false,
        int? value = null, [CallerMemberName] string name = null!) : base(value,
        name)
    {
        Type = type;
        Attrib = attrib;
        AttribValue = attribValue;
        Icon = icon;
        Label = label;
        AllowNull = allowNull;

        if (type.Equals(Btn)) options = new[] {this};

        if (options != null) Options = new(options);
    }

    public ToolBarGroupType Type { get; }

    public string Attrib { get; }

    public object? AttribValue { get; }

    public string? Label { get; }

    public string? Icon { get; }

    public bool AllowNull { get; }


    public ReadOnlyCollection<ToolBarOption>? Options { get; }

    public static ToolBarOption CustomToolBarOption(ToolBarGroup[] groups)
    {
        var events = groups.Select(g =>
                g.Events.Length == 1 && g.Events[0].Type.Equals(Group)
                    ? g.Events[0]
                    : new(Group, options: g.Events))
            .ToList();

        return new(ToolBarBase, options: events.ToArray());
    }

    public record ToolBarGroup(ToolBarOption[] Events);
}