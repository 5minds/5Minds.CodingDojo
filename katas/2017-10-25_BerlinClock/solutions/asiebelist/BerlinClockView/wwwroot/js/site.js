function callTimeUpdate() {

    $.ajax({
        url: "/BerlinClockTime/TimeUpdateAsync",
        type: "GET",
        dataType: "json",
        success: function (data) {
            //alert(data.fiveHours + '-' + data.singleHours + '-' + data.fiveMinutes + '-' + data.singleMinutes + '-' + data.seconds);
            drawClock(data.fiveHours, data.singleHours, data.fiveMinutes, data.singleMinutes, data.seconds);
        },
        error: function () {

            alert("Fehler");
        }
    });

}

function drawClock(fiveHours, singleHours, fiveMinutes, singleMinutes, seconds) {
    var canvas = new fabric.StaticCanvas('ClockCanvas');
    var secondsColor = 'white';
    if (seconds === 1) {
        secondsColor = 'yellow';
    }
    var secondCircle = new fabric.Circle({
        radius: 50,
        fill: secondsColor,
        strokeWidth: 5,
        stroke: 'rgba(160,160,160,0.8)',
        top: 0,
        left: 170

    });
    var fiveHourCount = fiveHours;
    for (var i = 1; i < 5; i++) {
        var fiveHoursPosx = ((i - 1) * 110);
        var fiveHourColor = 'white';
        if (fiveHourCount > 0) {
            fiveHourColor = 'red';
            fiveHourCount--;
        }
        var fiveHourRect = new fabric.Rect({
            left: fiveHoursPosx,
            top: 110,
            fill: fiveHourColor,
            strokeWidth: 5,
            stroke: 'rgba(160,160,160,0.8)',
            width: 100,
            height: 50
        });
        canvas.add(fiveHourRect);
    }
    var singleHourCount = singleHours;
    for (var i = 1; i < 5; i++) {
        var singleHoursPosx = ((i - 1) * 110);
        var singleHourColor = 'white';
        if (singleHourCount > 0) {
            singleHourColor = 'red';
            singleHourCount--;
        }
        var singleHourRect = new fabric.Rect({
            left: singleHoursPosx,
            top: 170,
            fill: singleHourColor,
            strokeWidth: 5,
            stroke: 'rgba(160,160,160,0.8)',
            width: 100,
            height: 50
        });
        canvas.add(singleHourRect);
    }

    var fiveMinCount = fiveMinutes;
    for (var i = 1; i < 12; i++) {
        var fiveMinPosx = ((i - 1) * 40);
        var fiveMinColor = 'white';
        if (fiveMinCount > 0) {
            if ((fiveMinCount + 2) % 3 == 0) {
                fiveMinColor = 'red';
            } else {
                fiveMinColor = 'yellow';
            }
            fiveMinCount--;
        }
        var fiveMinRect = new fabric.Rect({
            left: fiveMinPosx,
            top: 230,
            fill: fiveMinColor,
            strokeWidth: 5,
            stroke: 'rgba(160,160,160,0.8)',
            width: 30,
            height: 50
        });
        canvas.add(fiveMinRect);
    }

    var singleMinCount = singleMinutes;
    for (var i = 1; i < 5; i++) {
        var singleMinPosx = ((i - 1) * 110);
        var singleMinColor = 'white';
        if (singleMinCount > 0) {
            singleMinColor = 'yellow';
            singleMinCount--;
        }
        var singleMinRect = new fabric.Rect({
            left: singleMinPosx,
            top: 290,
            fill: singleMinColor,
            strokeWidth: 5,
            stroke: 'rgba(160,160,160,0.8)',
            width: 100,
            height: 50
        });
        canvas.add(singleMinRect);
    }

    canvas.add(secondCircle);
    canvas.add(rect);
}