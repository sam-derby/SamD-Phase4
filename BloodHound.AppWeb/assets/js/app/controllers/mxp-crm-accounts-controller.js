define(["services/data-service","services/wait-service","services/lync-service"],
    function (dataService,waitService,lyncService) {
        var sammyContext;
        var loadData = function(routeData) {
                var dataUrl = "/CrmData/GetMxpCrmRecords?custNumber=" + routeData.customerNumber;
                dataService.Get(dataUrl, null, function (data) {
                lyncService.resetControls();
                $.each(data, function (index, value) {
                    sammyContext.render("/assets/tmpl/partial/table-rows/vw-mxp-crm-accounts-table-row.template", { item: value })
                        .appendTo("#mxp-crm-accounts-table tbody")
                        .then(function () {
                            if (value.OwnerEmailAddress.length > 0) {
                                var parentCell = $("#td_" + value.AccountNumber);
                                lyncService.initialiseControl("nc_" + value.AccountNumber);

                                lyncService.addUser(value.OwnerEmailAddress, value.AccountNumber, parentCell, "nc_" + value.AccountNumber);
                            }
                        });
                });
                waitService.unblock();
            }, function(err) {
            });
        };
        var loadPageTemplate = function(routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-crm-accounts.template", {})
                .appendTo(sammyContext.$element())
                .then(function() {
                loadData(routeData);
            });
        };
        return {
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("Associated CRM Accounts");
                loadPageTemplate(routeData);
            }
        }
    });