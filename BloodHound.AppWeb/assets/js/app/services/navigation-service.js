define(["services/data-service", "ui/menu-ui"], function (dataService, menu) {
    var setPageDesc = function (customerNumber) {
        if (window.rootScope.context.currentMxpCutomer.CustomerNumber != undefined && window.rootScope.context.currentMxpCutomer === customerNumber) {
            $("#page-desc").text(window.rootScope.context.currentMxpCutomer.CustomerName);
        } else {
            var dataUrl = "/MxpData/GetCustomer?custNumber=" + customerNumber;
            dataService.Get(dataUrl, null, function (data) {
                var recentData = { id: data.CustomerNumber, name: data.CustomerName, type: "MXP" }
                window.rootScope.context.currentMxpCutomer = data;
                window.rootScope.context.addToRecent(recentData);
                $("#page-desc").text(data.CustomerName);
            });
        }
    };
    var configureMxpNavigation = function(routeData) {
        $("#mnu-mxp-home").attr("href", "#/mxp-home/" + routeData.customerNumber);
        $("#mnu-mxp-assoc-crm").attr("href", "#/mxp-crm-accounts/" + routeData.customerNumber);
        $("#mnu-mxp-contacts").attr("href", "#/mxp-contacts/" + routeData.customerNumber);
        $("#mnu-mxp-devices").attr("href", "#/mxp-devices/" + routeData.customerNumber);
        $("#mnu-mxp-contract-headers").attr("href", "#/mxp-contracts/" + routeData.customerNumber);
        $("#mnu-mxp-leases").attr("href", "#/mxp-leases/" + routeData.customerNumber);
        $("#mnu-mxp-service-calls").attr("href", "#/mxp-service-calls/" + routeData.customerNumber);
        setPageDesc(routeData.customerNumber);
    };
    var configureCrmNavigation = function (routeData) {
        $("#crm-mxp-home-list-item").show();
        if (window.rootScope.context.crmMxpCustomerNumber != undefined &&
            window.rootScope.context.crmMxpCustomerNumber != null &&
            window.rootScope.context.crmMxpCustomerNumber.length > 0) {
            routeData.customerNumber = window.rootScope.context.crmMxpCustomerNumber;
            $("#crm-mxp-home").attr("href", "#/mxp-home/" + routeData.customerNumber);
        } else {
            $("#crm-mxp-home-list-item").hide();
        }
        $("#mnu-crm-home").attr("href", "#/crm-home/" + routeData.accountNumber);
        $("#mnu-crm-contacts").attr("href", "#/crm-contacts/" + routeData.accountNumber);
        $("#mnu-crm-devices").attr("href", "#/crm-devices/" + routeData.accountNumber);
        $("#mnu-crm-opportunities").attr("href", "#/crm-opportunities/" + routeData.accountNumber);
    };
    var configureLeaseNavigation = function(routeData) {

        $("#mnu-mxp-devices").attr("href", "#/mxp-devices-leased/" + routeData.leaseId);
        $("#mnu-mxp-leases").attr("href", "#/mxp-leases-by-leaseId/" + routeData.leaseId);
    }

    var getNavMenu = function(appContext, callBack) {
        var template = "vw-mxp-nav-menu";
        if(appContext === "CRM")
            template = "vw-crm-nav-menu";
        else if (appContext === "LEASE")
            template = "vw-lease-nav-menu";
        dataService.LoadMenuTemplate(template, function (html) {
            var $menuContainer = $(".main-menu");
            $menuContainer.empty();
            var $html = $(html);
            $menuContainer.append($html.html());
            menu.init();
            callBack();
        });
    };
    return {
        configure: function (appContext, routeData) {
            $(".main-menu").empty();
            if (appContext === null) {
                return;
            }
            getNavMenu(appContext, function() {
                if (appContext === "MXP") {
                    configureMxpNavigation(routeData);
                } else if (appContext === "CRM") {
                    configureCrmNavigation(routeData);
                } else {
                    configureLeaseNavigation(routeData);
                }
                $(".main-nav").show();
                $(".main-menu").show();
            });
        }
    }
});

