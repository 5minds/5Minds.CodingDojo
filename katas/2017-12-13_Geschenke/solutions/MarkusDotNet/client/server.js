const path = require('path');
const koa = require('koa');
const serve = require('koa-static');

const startServer = function (port) {
    const app = new koa();
    app.use(serve(path.join(__dirname,"dist")));
    app.listen(port);
    console.log(`Listening on port ${port}`);
};

startServer(process.env.port)