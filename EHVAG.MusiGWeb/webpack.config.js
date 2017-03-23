  const debug = process.env.NODE_ENV !== 'production';
  const webpack = require('webpack');

  module.exports = {
      context: __dirname,
      devtool: debug ? 'inline-sourcemap' : null,
      devServer: {
          headers: {
              'Access-Control-Allow-Origin': '*',
          },
      },
      entry: './dev/js/index.jsx',
      module: {
          loaders: [
              {
                  test: /\.jsx?$/,
                  exclude: /(node_modules|bower_components)/,
                  loader: 'babel-loader',
                  query: {
                      presets: ['react', 'es2015', 'stage-0'],
                      plugins: ['react-html-attrs', 'transform-decorators-legacy', 'transform-class-properties'],
                  },
              },
              {
                  test: /\.scss$/,
                  loader: 'style!css!sass?outputStyle=compressed',
              },
          ],
      },
      sassLoader: {
          includePaths: [
              './node_modules',
          ],
      },
      resolve: {
          extensions: ['', '.js', '.jsx', '.scss', '.css'],
      },
      output: {
          path: `${__dirname}/src/`,
          filename: '/js/index.min.js',
      },
      plugins: debug ? [] : [
          new webpack.optimize.DedupePlugin(),
          new webpack.optimize.OccurenceOrderPlugin(),
          new webpack.optimize.UglifyJsPlugin({
              mangle: false,
              sourcemap: false,
          }),
      ],
  };