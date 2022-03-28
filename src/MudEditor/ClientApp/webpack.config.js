var path = require("path");
const webpack = require("webpack");
const RemoveEmptyScriptsPlugin = require("webpack-remove-empty-scripts");
const { merge } = require('webpack-merge');
const entries = require('./webpack.entries.js');

module.exports = merge(entries,{
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
        new webpack.ProvidePlugin({ "window.hljs": "highlight.js/lib/common" })
    ]
});