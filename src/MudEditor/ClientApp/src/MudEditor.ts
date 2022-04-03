import Quill from "./Quill";

export class MudEditor {
    private quill;

    constructor(private dotnetHelper: any, quillElement: any, placeholder: any) {
        const options = { modules: { syntax: true }, placeholder: placeholder };

        this.quill = new Quill(quillElement, options);
        this.quill.on("editor-change", this.editorChanged);
    }


    private editorChanged = (eventName: any, ...args: any[]) => {
        const formats = this.quill.getFormat();
        console.log(eventName, args);
        this.dotnetHelper.invokeMethodAsync("QuillGetFormat", formats);
    }

    dispose = () => {
        this.quill.off("editor-change", this.editorChanged);
    }

    format = (attrib: string, value:any) => {
        
        this.quill.format(attrib, value);
    }

    removeFormat = () => {
        this.quill.removeFormat();
    }

    updateOn = () => {
        this.quill.on("editor-change", this.editorChanged);
    }

    updateOff = () => {
        this.quill.off("editor-change", this.editorChanged);
    }
}