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
link.rel = "stylesheet";
link.href = "_content/MudEditor/MudEditor.min.css";
document.head.appendChild(link);


window["MudEditor"] = new MudEditorBase();