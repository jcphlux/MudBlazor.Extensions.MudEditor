using MudBlazor.Extensions.CustomIcons;
using MudBlazor.Extensions.Settings;
using MudBlazor.Extensions.ToolBarComponents;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MudBlazor.Extensions;

public class ToolBarAction : Enumeration
{
    private static readonly Type Expanded = typeof(ToolBarExpanded);
    private static readonly Type Menu = typeof(ToolBarMenu);
    private static readonly Type Toggle = typeof(ToolBarToggle);
    private static readonly Type List = typeof(ToolBarList);
    private static readonly Type Group = typeof(ToolBarBtnGroup);
    private static readonly Type Btn = typeof(ToolBarBtn);
    private static readonly Type ColorPicker = typeof(ToolBarColorPicker);
    private static readonly Type UrlDialog = typeof(ToolBarUrl);
    private static readonly Type ImagePicker = typeof(ToolBarImage);
    private static readonly Type ToolBarBase = typeof(object);
    

    public static readonly ToolBarAction Font = new(List, "format", "font");


    public static readonly ToolBarAction Size = new(List, "format", "size");


    public static readonly ToolBarAction BoldStyle = new(Btn, "format", "bold", "Bold", Icons.Filled.FormatBold, true);
    public static readonly ToolBarAction ItalicStyle = new(Btn, "format", "italic", "Italic", Icons.Filled.FormatItalic, true);
    public static readonly ToolBarAction UnderlineStyle = new(Btn, "format", "underline", "Underline", Icons.Filled.FormatUnderlined, true);
    public static readonly ToolBarAction StrikethroughStyle = new(Btn, "format", "strike", "Strikethrough", Icons.Filled.FormatStrikethrough, true);

    public static readonly ToolBarAction StyleGroup = new(Group, options: new[] { BoldStyle, ItalicStyle, UnderlineStyle, StrikethroughStyle });


    public static readonly ToolBarAction FontColor = new(ColorPicker, "format", "color", "Font Color", Icons.Filled.FormatColorText);
    public static readonly ToolBarAction BackgroundColor = new(ColorPicker, "format", "background", "Background Color", Icons.Filled.FontDownload);

    public static readonly ToolBarAction ColorGroup = new(Group, options: new[] { FontColor, BackgroundColor });


    public static readonly ToolBarAction Heading1 = new(Btn, "format", "header", "H1", MudEditorIcons.Icons.H1, 1);
    public static readonly ToolBarAction Heading2 = new(Btn, "format", "header", "H2", MudEditorIcons.Icons.H2, 2);
    public static readonly ToolBarAction Heading3 = new(Btn, "format", "header", "H3", MudEditorIcons.Icons.H3, 3);
    public static readonly ToolBarAction Heading4 = new(Btn, "format", "header", "H4", MudEditorIcons.Icons.H4, 4);
    public static readonly ToolBarAction Heading5 = new(Btn, "format", "header", "H5", MudEditorIcons.Icons.H5, 5);
    public static readonly ToolBarAction Heading6 = new(Btn, "format", "header", "H6", MudEditorIcons.Icons.H6, 6);

    public static readonly ToolBarAction HeadingMenu = new(Menu, attrib: "header", options: new[] { Heading1, Heading2, Heading3, Heading4, Heading5, Heading6 });
    public static readonly ToolBarAction HeadingExpanded = new(Expanded, attrib: "header", options: new[] { Heading1, Heading2, Heading3, Heading4, Heading5, Heading6 });

    public static readonly ToolBarAction Quote = new(Btn, "format", "blockquote", "Quote", Icons.Filled.FormatQuote, true);
    public static readonly ToolBarAction Code = new(Btn, "format", "code-block", "Code", Icons.Filled.Code, true);

    public static readonly ToolBarAction ListNumbered = new(Btn, "format", "list", "Numbered List", Icons.Filled.FormatListNumbered, "ordered");
    public static readonly ToolBarAction ListBulleted = new(Btn, "format", "list", "Bulleted List", Icons.Filled.FormatListBulleted, "bullet");

    public static readonly ToolBarAction ListGroup = new(Group, options: new[] { ListNumbered, ListBulleted });


    public static readonly ToolBarAction IndentIncrease = new(Btn, "format", "indent", "Increase Indent", Icons.Filled.FormatIndentIncrease, 1);
    public static readonly ToolBarAction IndentDecrease = new(Btn, "format", "indent", "Decrease Indent", Icons.Filled.FormatIndentDecrease, -1);

    public static readonly ToolBarAction IndentGroup = new(Group, options: new[] { IndentIncrease, IndentDecrease });


    public static readonly ToolBarAction AlignLeft = new(Btn, "format", "align", "Align Left", Icons.Filled.FormatAlignLeft);
    public static readonly ToolBarAction AlignCenter = new(Btn, "format", "align", "Align Center", Icons.Filled.FormatAlignCenter, "center");
    public static readonly ToolBarAction AlignRight = new(Btn, "format", "align", "Align Right", Icons.Filled.FormatAlignRight, "right");
    public static readonly ToolBarAction AlignJustify = new(Btn, "format", "align", "Justify", Icons.Filled.FormatAlignJustify, "justify");

    public static readonly ToolBarAction AlignmentMenu = new(Menu, attrib: "align", options: new[] { AlignLeft, AlignCenter, AlignRight, AlignJustify });
    public static readonly ToolBarAction AlignmentExpanded = new(Expanded, attrib: "align", options: new[] { AlignLeft, AlignCenter, AlignRight, AlignJustify });

    internal static readonly ToolBarAction Ltr = new(Btn, "format", "direction", "Left to Right", Icons.Filled.FormatTextdirectionLToR);
    internal static readonly ToolBarAction Rtl = new(Btn, "format", "direction", "Right to Left", Icons.Filled.FormatTextdirectionRToL, "rtl");

    public static readonly ToolBarAction LtrToggle = new(Toggle, attrib: "direction", options: new[] { Ltr, Rtl });
    public static readonly ToolBarAction LrtExpanded = new(Expanded, attrib: "direction", options: new[] { Ltr, Rtl });


    public static readonly ToolBarAction Link = new(UrlDialog, "format", "link", "Link", Icons.Filled.InsertLink);
    public static readonly ToolBarAction Image = new(ImagePicker, "format", "image", "Image", Icons.Filled.Image);
    public static readonly ToolBarAction Video = new(UrlDialog, "format", "video", "Video", Icons.Filled.OndemandVideo);

    public static readonly ToolBarAction MediaGroup = new(Group, options: new[] { Link, Image, Video });


    public static readonly ToolBarAction Formula = new(Btn, "format", "formula", "Formula", MudEditorIcons.Icons.Fx);
    public static readonly ToolBarAction Subscript = new(Btn, "format", "script", "Subscript", Icons.Filled.Subscript, "sub");
    public static readonly ToolBarAction Superscript = new(Btn, "format", "script", "Superscript", Icons.Filled.Superscript, "super");

    public static readonly ToolBarAction MathGroup = new(Group, options: new[] { Formula, Subscript, Superscript });


    public static readonly ToolBarAction FormatClear = new(Btn, "removeFormat", null!, "Clear Format", Icons.Filled.FormatClear);


    internal static readonly ToolBarAction Full =
        new(ToolBarBase,
            options: new[]
            {
                Font, Size, StyleGroup,
                ColorGroup, HeadingMenu,
                Quote, Code, ListGroup, 
                IndentGroup, AlignmentMenu,
                LtrToggle, MediaGroup,
                MathGroup, FormatClear
            });

    private ToolBarAction(Type type, string command = null!, string attrib = null!, string? label = null,
        string icon = null!, object? attribValue = null, ToolBarAction[]? options = null,
        int? value = null, [CallerMemberName] string name = null!) : base(value,
        name)
    {
        Type = type;
        Command = command;
        Attrib = attrib;
        AttribValue = attribValue;
        Icon = icon;
        Label = label;

        Actions = new(options ?? Array.Empty<ToolBarAction>());
    }

    internal Type Type { get; }

    internal string Command { get; }

    internal string Attrib { get; }

    internal object? AttribValue { get; }

    internal string? Label { get; }

    internal string? Icon { get; }

    internal ReadOnlyCollection<ToolBarAction> Actions { get; }

    internal IDictionary<string, object> Parameters(MudEditor editor) => new Dictionary<string, object>
    {
        {"Editor", editor},
        {"Action", this}
    };

    internal static ToolBarAction CustomToolBarOption(ToolBarGroup[] groups)
    {
        var events = groups.Select(g =>
                g.Actions.Length == 1 && g.Actions[0].Type == Group
                    ? g.Actions[0]
                    : new(Group, options: g.Actions))
            .ToList();

        return new(ToolBarBase, options: events.ToArray());
    }

    public record ToolBarGroup(ToolBarAction[] Actions);
}