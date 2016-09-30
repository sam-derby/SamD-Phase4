define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var loadData = function (routeData) {
            var dataUrl = "/MxpData/GetContactsSummary?custNumber=" + routeData.customerNumber;
            dataService.Get(dataUrl, null, function(data) {
                $.each(data, function(index, value) {
                    sammyContext.render("/assets/tmpl/partial/table-rows/vw-mxp-contacts-table-row.template", { rowId: index + 1, item: value })
                        .appendTo("#mxp-contacts-table tbody")
                        .then(function () {
                            var table = document.getElementById("mxp-contacts-table");
                            var rows = table.rows;
                            if (routeData.contactId != undefined && routeData.contactId.length > 0) {
                                $.each(rows, function (index, row) {
                                    if (row.id === routeData.contactId) {
                                        row.click();
                                        return;
                                    }
                                });
                            } else {
                                if (rows.length > 1) {
                                    var firstRow = rows[1];
                                    firstRow.click();
                                }
                            }
                        });
                });
                $("#mxp-contacts-table tbody").on("click", "tr", function () {
                    $("#mxp-contacts-table tr.selected").removeClass("selected");
                    $(this).addClass("selected");
                    var email = $(this).attr("data-email");
                    var name = $(this).attr("data-name");
                    var phone = $(this).attr("data-phone");
                    var mobile = $(this).attr("data-mobile");
                    $("#mxp-contact-profile").show();
                    $("#lbl-mxp-cust-name").text(name);
                    $("#lbl-mxp-cust-mobile").text(mobile);
                    $("#lbl-mxp-cust-phone").text(phone);
                    $("#lbl-mxp-cust-email").text(email);
                    $("#lbl-mxp-cust-email").attr("href", "mailto:" + email);
                });
                waitService.unblock();
            });
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-contacts.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    loadData(routeData);
                });
        };
        return {
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Contacts");
                loadPageTemplate(routeData);
            }
        }
});