define([],function () {
    return {
        CheckAndHandleError: function (data, $errorContainer) {
            if (data.ErrorCode != undefined || data.ErrorCode != null) {
                var $errorMessage = "<div class='alert alert-danger alert-dismissable'>" +
                    "<a href='' class='close'>×</a>" +
                    "<strong>Oh No!</strong>" + data.Message + "</div>";
                if ($errorContainer != undefined) {
                    $errorContainer.empty();
                    $errorContainer.append($errorMessage);
                   
                } else {
                    $("#main-error-container").empty();
                    $("#main-error-container").append($errorMessage);
                }
            }
       }
    }
});

