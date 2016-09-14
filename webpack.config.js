var path = require("path"),
    webpack = require("webpack");

module.exports = {
  devtool: "source-map",
  entry: "./temp/fsharpsources.js",
  output: {
    path: path.join(__dirname, "dist"),
    filename: "app.js"
  },
  module: {
    preLoaders: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        loader: "source-map-loader"
      }
    ]
  }
};