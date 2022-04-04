﻿import Quill from "./Quill";

export class MudEditor {
    private quill;

    constructor(private dotnetHelper: any, quillElement: any, placeholder: any) {
        const options = { modules: { syntax: true }, placeholder: placeholder };

        this.quill = new Quill(quillElement, options);
        this.updateOn();
    }


    private editorChanged = (range, oldRange, source) => {
        const formats = this.quill.getFormat();
        this.dotnetHelper.invokeMethodAsync("SetSelectionInfo", { formats, range });
    }

    getSelectionInfo = () => {
        const formats = this.quill.getFormat();
        const range = this.quill.getSelection();
        return {formats, range};
    }

    dispose = () => this.quill.updateOff();

    format = (attrib: string, value:any) => this.quill.format(attrib, value);

    removeFormat = (index: Number, length: Number) => this.quill.removeFormat(index, length);

    updateOn = () => this.quill.on("selection-change", this.editorChanged);

    updateOff = () => this.quill.off("selection-change", this.editorChanged);
}