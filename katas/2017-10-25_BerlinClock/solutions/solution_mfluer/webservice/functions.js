function parsetime(now) {
    const hourFives = Math.floor(now.getHours() / 5);
    const hourRest = now.getHours() % 5
    const minuteFives = Math.floor(now.getMinutes() / 5);
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
    return "█".repeat(parseInt(timeObjectHours, 10)).padEnd(4, "▁")
}

function renderFiftyFive(timeObjectMinutes) {
    return "■".repeat(parseInt(timeObjectMinutes, 10)).padEnd(11, "▢")
}

module.exports = {
    parsetime, renderSecond, renderFourBlock, renderFiftyFive
}