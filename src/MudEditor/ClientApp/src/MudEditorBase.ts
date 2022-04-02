import { MudEditor } from "./MudEditor"

class MudEditorBase {
    private editors = new Map<number, MudEditor>();

    create = (dotnetHelper: any, quillElement: any, placeholder: any): MudEditor => {
        var editor = new MudEditor(dotnetHelper, quillElement, placeholder);

        this.editors.set(dotnetHelper._id, editor);

        return editor;
    };

    remove = (dotnetHelper: any) => {
        const id = dotnetHelper._id;
        if (this.editors.has(id)) {
            this.editors.get(id)?.stuff();
            this.editors.delete(id);
        }
    };
}

var link = document.createElement("link");
link.href = "_content/MudEditor/MudEditor.min.css";
link.rel = "stylesheet";

document.querySelector('link[rel="stylesheet"][href="_content/MudBlazor/MudBlazor.min.css"]').after(link);


window["MudEditor"] = new MudEditorBase();