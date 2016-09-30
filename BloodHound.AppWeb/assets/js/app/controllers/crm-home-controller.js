define(["services/data-service","services/wait-service","services/lync-service"],
    function (dataService,waitService,lyncService) {
        var sammyContext;
        var loadAccountInfo = function (data) {
            sammyContext.render("/assets/tmpl/partial/vw-crm-home-account.template", { item: data })
                .appendTo("#crm-account-info-widget")
                .then(function () {
                    lyncService.resetControls();
                    lyncService.initialiseControl("nc_" + data.OwnerId, 1);
                    if (data.PrimarySalesContact.length > 0 && data.PrimaryContactId.length > 0) {
                        $("#crm-prim-sales-contact").html("<a href='#/crm-contacts/" + data.AccountNumber + "/" + data.PrimaryContactId + "'>" + data.PrimarySalesContact + "</a>");
                    }
                    if (data.OwnerName.length > 0 && data.OwnerEmailAddress.length > 0) {
                        lyncService.addUser(data.OwnerEmailAddress, data.OwnerId, $("#crm-account-owner"),"nc_" + data.OwnerId);
                    }
                    if (data.PrimaryServiceContact.length > 0 && data.PrimaryGeneralContactId.length > 0) {
                        $("#crm-prim-serv-contact").html("<a href='#/crm-contacts/" + data.AccountNumber + "/" + data.PrimaryGeneralContactId + "'>" + data.PrimaryServiceContact + "</a>");
                    }
                    if (data.MxpCustomerNumber.length > 0) {
                        $("#crm-mxp-customerId").html("<a href='#/mxp-home/" + data.MxpCustomerNumber + "'>" + data.MxpCustomerNumber + "</a>");
                    }
                    if (data.ParentAccountId.length > 0) {
                        $("#crm-parent").html("<a href='#/crm-home/" + data.ParentAccountId + "'>" + data.ParentAccountName + "</a>");
                    }
                    if (data.CrmSharepointUrl != undefined && data.CrmSharepointUrl.length === 0) {
                        $("#crm-sp-site-link-container").hide();
                    }
                });
        };
        var loadAddressInfo = function(data) {
            sammyContext.render("/assets/tmpl/partial/vw-crm-home-address.template", { item: data })
                .appendTo("#crm-address-widget");
        };
        var loadContacts = function(accountNumber) {
            sammyContext.render("/assets/tmpl/partial/vw-crm-home-contacts.template", null)
                .appendTo("#crm-contacts-widget")
                .then(function() {
                    var dataUrl = "/CrmData/GetCrmContacts?accountNumber=" + accountNumber;
                    dataService.Get(dataUrl, null, function (data) {
                        $.each(data, function (index, value) {
                            sammyContext.render("/assets/tmpl/partial/table-rows/vw-crm-home-contacts-table-row.template", {item: value })
                                .appendTo("#crm-home-contacts-table tbody");
                        });
                    });
                    waitService.unblock();
                });
        };
        var loadPageTemplate = function(data) {
            sammyContext.render("/assets/tmpl/page/vw-crm-home.template", {})
                .appendTo(sammyContext.$element())
                .then(function() {
                    loadAccountInfo(data);
                    loadAddressInfo(data);
                    loadContacts(data.AccountNumber);
            });
        };
        return {
            
            load: function (context, routeData) {
                sammyContext = context;
                $("#page-title").text("CRM Home");
                var dataUrl = "/CrmData/GetAccount?accountNumber=" + routeData.accountNumber;
                waitService.block();
                dataService.Get(dataUrl, null, function(data) {
                    var recentData = { id: data.AccountNumber, name: data.AccountName , type: "CRM"}
                    window.rootScope.context.addToRecent(recentData);
                    $("#page-desc").text(data.AccountName);
                    loadPageTemplate(data);
                    if (data.MxpCustomerNumber != undefined && data.MxpCustomerNumber != null && data.MxpCustomerNumber.length > 0) {
                        $("#crm-mxp-home").attr("href", "#/mxp-home/" + data.MxpCustomerNumber);
                        window.rootScope.context.crmMxpCustomerNumber = data.MxpCustomerNumber;
                    } else {
                        window.rootScope.context.crmMxpCustomerNumber = "";
                        $("#crm-mxp-home").attr("href", "#");
                        $("#crm-mxp-home").parent().hide();
                    }
                });
            }
        }
    });