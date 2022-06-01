// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

var path = require("path");

module.exports = {
    mode: "development",
    entry: "./src/Client.fs.js",
    output: {
        path: path.join(__dirname, "./dist"),
        filename: "dhsysClient.js",
    }
}