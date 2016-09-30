define([],
    function () {
        var selectedDataKey = "mxp-cust-no";
        return {
            init: function () {

                $("#txt-search").keyup(function () {
                    var data = $(this).val();
                    if (data.length > 2 || data.length > 2) {
                        var searchUrl = "#/search/" + selectedDataKey + "/" + data;
                        $("#btn-search").attr("href", searchUrl);
                        $("#btn-search").removeClass("disabled");
                    } else {
                        if (!$("#btn-search").hasClass("disabled")) {
                            $("#btn-search").addClass("disabled");
                        }
                    }
                });
                $("#txt-search").keypress(function (event) {

                    if (event.which === 13) {
                        $("#btn-search").click();
                        event.preventDefault();
                    }

                });
                $("#txt-search").on("paste", function () {
                    var element = this;
                    setTimeout(function () {
                        var data = $(element).val();
                        if (data.length > 2 || data.length > 2) {
                            var searchUrl = "#/search/" + selectedDataKey + "/" + data;
                            $("#btn-search").attr("href", searchUrl);
                            $("#btn-search").removeClass("disabled");
                        } else {
                            if (!$("#btn-search").hasClass("disabled")) {
                                $("#btn-search").addClass("disabled");
                            }
                        }
                    }, 100);
                });
                $(".search-select").click(function () {
                    var name = $(this).text();
                    $("#search-by-text").text(name);
                    var data = $("#txt-search").val();
                    selectedDataKey = $(this).attr("data-key");
                    var searchUrl = "#/search/" + selectedDataKey + "/" + data;
                    $("#btn-search").attr("href", searchUrl);
                    $("#btn-search").attr("data-key", selectedDataKey);
                });
                $("#btn-search").click(function () {
                    var dataKey = $(this).attr("data-key");
                    if ($(this).hasClass("disabled") || dataKey.length === 0) {
                        return false;
                    }
                    $(".main-nav").hide();
                });
            }
        }
});