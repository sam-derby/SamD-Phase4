define(["services/response-service"], function (responseservice) {
    return {
        Get: function (url, actionData, onSuccess, onError) {
            var spUrl = window.rootScope.sharepointContext.siteUrl;
            setTimeout(function () {
                $.ajax({
                    type: "GET",
                    url: url + "&SPHostUrl=" + spUrl,
                    data: actionData,
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        $("#main-error-container").empty();
                        if (data.ResponseCode === 200) {
                            onSuccess(data.Data);
                        } else if (data.ResponseCode === 204) {
                            responseservice.HandleResponse(data);
                            onSuccess(data.Data);
                        } else {
                            responseservice.HandleResponse(data);
                        }
                    },
                    error: onError
                });
            }, 0);
           
        },
        LoadMenuTemplate: function (view, done) {
            $.ajax({
                type: "GET",
                url: "assets/tmpl/nav/" + view + ".html",
                dataType: "html"
            }).done(done)
                .fail(function () {
                    var $errorMessagePanel = $(".app-error");
                    $errorMessagePanel.html("Error loading template");
                }).always();
        },
     
        LoadSearchResultsViewTemplate: function (view, done) {
            $.ajax({
                type: "GET",
                url: "assets/tmpl/search/" + view + ".html",
                dataType: "html"
            }).done(done)
                .fail(function () {
                    var $errorMessagePanel = $(".app-error");
                    $errorMessagePanel.html("Error loading template");
                }).always();
    }
    }
});

