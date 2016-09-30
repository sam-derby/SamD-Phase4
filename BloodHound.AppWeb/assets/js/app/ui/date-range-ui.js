define([],
    function () {
        return {
            init: function (datecontainer, callback, startDate, endDate) {
                $(datecontainer).daterangepicker({
                    startDate: startDate,
                    endDate: endDate,
                    minDate: "01/01/1970",
                    maxDate: "12/31/2024",
                    showDropdowns: true,
                    showWeekNumbers: true,
                    timePicker: false,
                    timePickerIncrement: 1,
                    timePicker12Hour: true,
                    ranges: {
                        "Last 7 Days": [moment().subtract("days", 7), moment()],
                        "This Month": [moment().startOf("month"), moment()],
                        "Last Month": [moment().subtract("month", 1).startOf("month"), moment().subtract("month", 1).endOf("month")],
                        "Last 3 Months": [moment().subtract("months", 3), moment()],
                        "Last 6 Months": [moment().subtract("months", 6), moment()],
                        "Last 12 Months": [moment().subtract("months", 12), moment()],
                        "Last 24 Months": [moment().subtract("months", 24), moment()]
                    },
                    opens: "left",
                    buttonClasses: ["btn btn-info"],
                    applyClass: "btn-small btn-info",
                    cancelClass: "btn-small",
                    format: "DD/MM/YYYY",
                    separator: " to ",
                    locale: {
                        applyLabel: "Add Range",
                        fromLabel: "From",
                        toLabel: "To",
                        customRangeLabel: "Custom Range",
                        daysOfWeek: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"],
                        monthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                        firstDay: 1
                    }
                },

                function (start, end) {

                    $(datecontainer + " span").html(start.format("D MMMM YYYY") + " - " + end.format("D MMMM YYYY"));
                    callback(moment(start), moment(end));
                }
            );
                $(datecontainer + " span").html(startDate.format("D MMMM YYYY") + " - " + endDate.format("D MMMM YYYY"));
            }
        }
});