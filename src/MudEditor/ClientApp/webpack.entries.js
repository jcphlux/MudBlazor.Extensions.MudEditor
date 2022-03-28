var path = require("path");

module.exports = {
    entry: {
        MudEditor: path.resolve(__dirname, "./src/MudEditorBase.ts"),
        MudEditorStyles: path.resolve(__dirname, "./styles/MudEditor.scss")
    }
};