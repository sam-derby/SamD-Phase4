define([], function (now) {
    var dateMinusSevenDays = function () {
        return now.subtract(7, "days");
    };
    var dateMinusThreeMonths = function () {
        return now.subtract(3, "months");
    };
    var dateMinusSixMonths = function () {
        return now.subtract(6, "months");
    };
    var dateMinusTwelveMonths = function () {
        return now.subtract(12, "months");
    };
    var dateMinusTwentyFourMonths = function () {
        return now.subtract(24, "months");
    };
    var firstDayOfThisMonth = function () {
        return now.startOf("month");
    };
    var firstDayOfLastMonth = function () {
        return now.subtract(1, "months").startOf("month");
    };
    var lastDayOfLastMonth = function () {
        return now.subtract(1, "months").endOf("month");
    };

    var getDatePeriod = function(spanType) {
        var pastDate = "";
        var startDate = moment();
        switch(spanType) {
            case 1:
                pastDate = dateMinusSevenDays(startDate);
                break;
            case 2:
                pastDate = dateMinusThreeMonths(startDate);
                break;
            case 3:
                pastDate = dateMinusSixMonths(startDate);
                break;
            case 4:
                pastDate = dateMinusTwelveMonths(startDate);
                break;
            case 5:
                pastDate = dateMinusTwentyFourMonths(startDate);
                break;
            case 6:
                pastDate = firstDayOfThisMonth(startDate);
                break;
            case 7:
                pastDate = firstDayOfLastMonth(startDate);
                break;
            case 8:
                pastDate = lastDayOfLastMonth(startDate);
                break;
        }
        return {
            startDateStr : pastDate.format("DD-MM-YYYY"),
            nowDateStr : startDate.format("DD-MM-YYYY")
        }
    };
    return {
       spanType : getDatePeriod
    }
});


