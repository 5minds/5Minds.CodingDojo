const koa = require("koa");
const {parsetime} = require('./functions');

const Koa = require('koa');
const app = new Koa();

app.use(async (ctx,next)=> {
   console.log("Request issued. RequestUrl: ", ctx.url);
   return next();
});

app.use(async (ctx,next)=> {
    console.log("Setting time object");
    let now = new Date();
    if(ctx.request.query && ctx.request.query.datetime) {
        now = new Date(ctx.request.query.datetime);
    }
    const timeObject = parsetime(now);
    ctx.timeContext = timeObject;
    return next();
});

app.use(async (ctx,next)=> {
    console.log("Setting json header");
    ctx.response.is('application/json');
    ctx.response.type ='application/json';
    ctx.headers["Content-Type"] = 'application/json';
    ctx.headers["Access-Control-Allow-Origin"] = '*';
    ctx.set("Access-Control-Allow-Origin", '*');
    return next();
});

app.use(async (ctx, next)=> {
  if(/\/minutes(\?.*)?$/.test(ctx.url)) {
      ctx.headers["Content-Type"] = 'application/json';
      ctx.body = JSON.stringify({
        minuteFives: ctx.timeContext.minuteFives,
        minuteRest: ctx.timeContext.minuteRest
      })
      return;
  }
  return next();
});
app.use(async (ctx,next) => {
    if(/\/seconds(\?.*)?$/.test(ctx.url)) {
        ctx.body = JSON.stringify({
            seconds: ctx.timeContext.seconds
        })
        return;
    }
    return next();
});
app.use(async (ctx,next) => {
    if(/\/hours(\?.*)?$/.test(ctx.url)) {
        ctx.body = JSON.stringify({
          hourFives: ctx.timeContext.hourFives,
          hourRest: ctx.timeContext.hourRest
        })
        return;
    }
    return next();
});
app.use(async (ctx,next) => {
    if(/\/full(\?.*)?$/.test(ctx.url)) {
        ctx.body = JSON.stringify(ctx.timeContext);
        return;
    }
    return next();
});
app.use(async (ctx,next) => {
    ctx.body = JSON.stringify({error: "Set parameter"});
    return next();
});

app.listen(3000);
console.log("Service listening on 3000");