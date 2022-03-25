import Quill from "./Quill";

export class MudEditor {
    private quill;

    constructor(private dotnetHelper, quillElement, placeholder) {
        const options = { modules: { syntax: true }, placeholder: placeholder };

        this.quill = new Quill(quillElement, options);
        this.quill.setText("Hello World!");
        this.quill.formatText(0, 2, "bold", true);
        this.quill.formatText(1, 2, "italic", true);
        this.quill.getFormat(0, 2);   // { bold: true }
        this.quill.getFormat(1, 1);   // { bold: true, italic: true }

        this.quill.formatText(0, 2, "color", "red");
        this.quill.formatText(2, 1, "color", "blue");
        this.quill.getFormat(0, 3);   // { color: ['red', 'blue'] }

        this.quill.setSelection(3);
        this.quill.getFormat();       // { italic: true, color: 'blue' }

        this.quill.format("strike", true);
        this.quill.getFormat();       // { italic: true, color: 'blue', strike: true }

        this.quill.formatLine(0, 1, "align", "right");
        this.quill.on("editor-change", this.editorChanged);
    }


    private editorChanged = (eventName, ...args) => {
        //if (source !== "user" || !range)
        //    return;

        const formats = this.quill.getFormat();
        console.log(formats);
        this.dotnetHelper.invokeMethodAsync("QuillGetFormat", formats);
    }

    stuff = () => {
        this.quill.off("editor-change", this.editorChanged);
    }

    format = (attrib, value) => {
        
        this.quill.format(attrib, value);
    }

    resetFormat = () => {
        this.quill.removeFormat();
    }

    focus = () => {
        this.quill.focus();
    }
}