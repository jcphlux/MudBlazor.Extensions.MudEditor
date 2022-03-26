var path = require("path");

const webpack = require("webpack");
const RemoveEmptyScriptsPlugin = require("webpack-remove-empty-scripts");
const FileManagerPlugin = require("filemanager-webpack-plugin");

module.exports = {
    entry: {
        MudEditor: path.resolve(__dirname, "./src/MudEditorBase.ts"),
        MudEditorStyles: path.resolve(__dirname, "./styles/MudEditor.scss")
    },
    optimization: {
        runtimeChunk: false
    },
    resolve: {
        alias: {
            'quill-css': path.resolve(__dirname, "./node_modules/quill/dist/quill.core.css")
        },
        extensions: [".ts", ".js", ".scss", ".css"]
    },
    output: {
        path: path.resolve(__dirname, "../wwwroot"),
        filename: "[name].min.js",
        publicPath: "_content/MudEditor/" // << See note
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: "ts-loader",
                exclude: /node_modules/
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: []
            },
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                type: "asset/resource",
                generator: {
                    filename: "[name].min.css"
                },
                use: ["sass-loader"]
            },
            {
                test: /\.css$/,
                exclude: /node_modules/,
                type: "asset/resource",
                generator: {
                    filename: "[name].min.css"
                },
                use: []
            }
        ]
    },
    plugins: [
        new RemoveEmptyScriptsPlugin(),
        new FileManagerPlugin({
            events: {
                onEnd: {
                    copy: [
                        { source: "../wwwroot/MudEditor.min.css", destination: "../Components/MudEditor.razor.css" }
                    ]
                }
            }
        }),
        new webpack.ProvidePlugin({ "window.hljs": "highlight.js/lib/common" })
    ]
};