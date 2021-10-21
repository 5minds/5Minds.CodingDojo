const readline = require("readline");
const rl = readline.createInterface(process.stdin);

function parsetime(now) {
    const hourFives = Math.floor(now.getHours() / 5);
    const hourRest = now.getHours()%5
    const minuteFives = Math.floor(now.getMinutes()/5);
    const minuteRest = now.getMinutes() % 5;
    const second = now.getSeconds() % 2;

    return {
        hourFives,
        hourRest,
        minuteFives,
        minuteRest,
        second
    }
}

function renderSecond(timeObjectSecond) {
    return timeObjectSecond === 0 ? "⊙" : "⬤";
}

function renderFourBlock(timeObjectHours) {
    return "█".repeat(parseInt(timeObjectHours,10)).padEnd(4,"▁")
}

function renderFiftyFive(timeObjectMinutes) {
    return "■".repeat(parseInt(timeObjectMinutes, 10)).padEnd(55,"▢")
}

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