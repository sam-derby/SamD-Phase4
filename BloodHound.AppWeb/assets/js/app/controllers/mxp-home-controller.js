define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var loadCustomerInfo = function (data) {
            sammyContext.render("/assets/tmpl/partial/vw-mxp-home-company.template", { item: data })
                .appendTo("#mxp-company-info-widget")
                .then(function() {
                    if (data.ChargeCustomerNumber.length > 0 && data.Charge === "No") {
                        $("#mxp-charge-cust-no").html("<a href='#/mxp-home/" + data.ChargeCustomerNumber + "'>" + data.ChargeCustomerNumber + "</a>");
                    }
                });
        };
        var loadAddressInfo = function(data) {
            sammyContext.render("/assets/tmpl/partial/vw-mxp-home-address.template", { item: data })
                .appendTo("#mxp-address-widget");
        };
        var loadContacts = function(customerNumber) {
            sammyContext.render("/assets/tmpl/partial/vw-mxp-home-contacts.template", null)
                .appendTo("#mxp-contacts-widget")
                .then(function() {
                    var dataUrl = "/MxpData/GetContactsSummary?custNumber=" + customerNumber;
                    dataService.Get(dataUrl, null, function (data) {
                        $.each(data, function (index, value) {
                            sammyContext.render("/assets/tmpl/partial/table-rows/vw-mxp-home-contacts-table-row.template", {rowId : index + 1, item: value })
                                .appendTo("#mxp-home-contacts-table tbody");
                        });
                        waitService.unblock();
                    });
                });
        };
        var loadPageTemplate = function(data) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-home.template", {})
                .appendTo(sammyContext.$element())
                .then(function() {
                    loadCustomerInfo(data);
                    loadAddressInfo(data);
                    loadContacts(data.CustomerNumber);
            });
        };
        return {
            
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Home");
                var dataUrl = "/MxpData/GetCustomer?custNumber=" + routeData.customerNumber;
                dataService.Get(dataUrl, null, function(data) {
                    var recentData = { id: data.CustomerNumber, name: data.CustomerName , type: "MXP"}
                    window.rootScope.context.addToRecent(recentData);
                    window.rootScope.context.crmMxpCustomerNumber = data.CustomerNumber;
                    $("#page-desc").text(data.CustomerName);
                    loadPageTemplate(data);
                });

            }
        }
    });