define(["services/wait-service"], function (waitService) {
    return {
        HandleResponse: function (data) {
            waitService.unblock();
           
            if (data.ResponseCode === 500) {
                $(".main-content").empty();
                $("#main-error-container").append("<div class='alert alert-danger'><strong>500 Internal Server Error - </strong>" + data.Message + "</div>");
            }
            if (data.ResponseCode === 403) {
                $(".main-content").empty();
                $("#main-error-container").append("<div class='alert alert-danger'><strong>403 Forbidden - </strong>" + data.Message + "</div>");
            }
            if (data.ResponseCode === 404) {
                $(".main-content").empty();
                $("#main-error-container").append("<div class='alert alert-warning'><strong>Item Not Found - </strong>" + data.Message + "</div>");
            }
            if (data.ResponseCode === 204) {
                $("#main-error-container").append("<div class='alert alert-info'><strong>No Content Found - </strong>" + data.Message + "</div>");
            }
        }
    }
});

