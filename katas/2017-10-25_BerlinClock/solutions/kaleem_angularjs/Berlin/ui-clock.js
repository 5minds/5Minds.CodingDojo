var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $interval) {
   
    $scope.date = new Date();

    $scope.hours = $scope.date.getHours();
    $scope.minutes = $scope.date.getMinutes();
    $scope.seconds = $scope.date.getSeconds();

    $scope.secondsValue = _seconds();
    $scope.hoursTop = _hoursTop();
    $scope.hoursBottom = _hoursBottom();
    $scope.minutesTop = _minutesTop();
    $scope.minutesBottom = _minutesBottom();

    function _seconds() {
        if ($scope.seconds % 2 == 0)
            return "1";
        else
            return "O";
    }
    function _hoursTop() {
        return ($scope.hours - ($scope.hours % 5)) / 5;
    }
    function _hoursBottom() {
        return ($scope.hours % 5);
    }
    function _minutesTop() {
        return ($scope.minutes - ($scope.minutes % 5)) / 5;
    }
    function _minutesBottom() {
        return ($scope.minutes % 5);
    }

    $interval(function () {
        $scope.date = new Date();
        $scope.seconds = $scope.date.getSeconds();
        $scope.secondsValue = _seconds();
    }, 1000);
});