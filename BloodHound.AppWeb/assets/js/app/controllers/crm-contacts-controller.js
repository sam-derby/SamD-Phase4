define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var loadData = function (routeData) {
            var dataUrl = "/CrmData/GetCrmContacts?accountNumber=" + routeData.accountNumber;
            dataService.Get(dataUrl, null, function (data) {
                $.each(data, function (index, value) {
                    sammyContext.render("/assets/tmpl/partial/table-rows/vw-crm-contacts-table-row.template", { item: value })
                        .appendTo("#crm-contacts-table tbody")
                        .then(function () {
                        waitService.unblock();
                            var table = document.getElementById("crm-contacts-table");
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
                $("#crm-contacts-table tbody").on("click", "tr", function () {
                    $("#crm-contacts-table tr.selected").removeClass("selected");
                    $(this).addClass("selected");
                    var email = $(this).attr("data-emailAddress");
                    var name = $(this).attr("data-name");
                    var phone = $(this).attr("data-phone");
                    var mobile = $(this).attr("data-mobile");
                    $("#crm-contact-profile").show();
                    $("#lbl-crm-cust-name").text(name);
                    $("#lbl-crm-cust-mobile").text(mobile);
                    $("#lbl-crm-cust-phone").text(phone);
                    $("#lbl-crm-cust-email").text(email);
                    $("#lbl-crm-cust-email").attr("href", "mailto:" + email);
                });
            });
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-crm-contacts.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    waitService.block();
                    loadData(routeData);
                });
        };
        return {
            load: function (context, routeData) {
                sammyContext = context;
                $("#page-title").text("CRM Contacts");
                loadPageTemplate(routeData);
            }
        }
    });