const readline = require("readline");
const rl = readline.createInterface(process.stdin);
const {parsetime, renderSecond, renderFourBlock, renderFiftyFive} = require('./functions')
function renderClockLine({
    hourFives,
    hourRest,
    minuteFives,
    minuteRest,
    second
}) {
    return `( ${renderSecond(second)} ) | [ ${renderFourBlock(hourFives)}][ ${renderFourBlock(hourRest)}] | { ${renderFiftyFive(minuteFives)} }{ ${renderFourBlock(minuteRest)} }`;
}

function renderTime() {
    const now = new Date();
    const timeObject = parsetime(now);
    const outString = renderClockLine(timeObject);
    // process.stdout.clearLine(0);
    process.stdout.cursorTo(0);
    process.stdout.write(outString.replace(/\n/,""));
}

function run() {
    renderTime();
    setInterval(renderTime,1000);
}

console.log("Welcome to the Berlin Clock. Press enter to exit");
run();

rl.on('line', (input) => {
    rl.close();
    process.exit();
})