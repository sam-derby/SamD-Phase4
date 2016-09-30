define(["require", "services/controller-service", "services/navigation-service", "services/recent-service", "services/data-service"], function (require, controllerService, navigationService, recent, dataService) {
    var load = function (controllerName, context, routeData, appContext) {
        recent.hideRecent();
        navigationService.configure(appContext, routeData);
        var controller = controllerService.getController(controllerName);
        context.app.swap("");
        controller.load(context, routeData);
        window.rootScope.context.heartbeat = setTimeout(function () {
            var dataUrl = "/MxpData/KeepAlive?data=1";
            dataService.Get(dataUrl, null, function (data) {
                if (window.rootScope.context.heartbeat != undefined && window.rootScope.context.heartbeat != null) {
                    clearTimeout(window.rootScope.context.heartbeat);
                }
                window.location.href = window.location.href;
            });
        }, 600000);
    };
    return {
        init: function () {
            var sammyApp = $.sammy(function () {
                this.use("Template");
                this.clearTemplateCache();
                this.element_selector = "#main-content";
                this.get("#/search/:filter/:value", function (context) {
                    load("search", context, { filter: this.params["filter"], value: this.params["value"] }, null);
                });
                this.get("#/mxp-home/:customerNumber", function (context) {
                    load("mxp-home", context, { customerNumber: this.params["customerNumber"]}, "MXP");
                });
                this.get("#/crm-home/:accountNumber", function (context) {
                    load("crm-home", context, { accountNumber: this.params["accountNumber"] }, "CRM");
                });
                this.get("#/crm-contacts/:accountNumber", function (context) {
                    load("crm-contacts", context, { accountNumber: this.params["accountNumber"] }, "CRM");
                });
                this.get("#/mxp-crm-accounts/:customerNumber", function (context) {
                    load("mxp-crm-accounts", context, { customerNumber: this.params["customerNumber"]}, "MXP");
                });
                this.get("#/crm-contacts/:accountNumber/:contactId", function (context) {
                    load("crm-contacts", context, { accountNumber: this.params["accountNumber"], contactId: this.params["contactId"] }, "CRM");
                });
                this.get("#/mxp-contacts/:customerNumber", function (context) {
                    load("mxp-contacts", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-contacts/:customerNumber/:contactId", function (context) {
                    load("mxp-contacts", context, { customerNumber: this.params["customerNumber"], contactId: this.params["contactId"] }, "MXP");
                });
                this.get("#/mxp-devices/:customerNumber", function (context) {
                    load("mxp-devices", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-devices-leased/:leaseId", function (context) {
                    load("mxp-devices", context, { leaseId: this.params["leaseId"] }, "LEASE");
                });
                this.get("#/mxp-devices-leased/:customerNumber/:leaseId/:devbylease", function (context) {
                    load("mxp-devices", context, { customerNumber: this.params["customerNumber"], leaseId: this.params["leaseId"], devbylease: this.params["devbylease"] }, "MXP");
                });
                this.get("#/crm-devices/:accountNumber", function (context) {
                    load("crm-devices", context, { accountNumber: this.params["accountNumber"] }, "CRM");
                });
                this.get("#/mxp-devices/:customerNumber/:sysRef", function (context) {
                    load("mxp-devices", context, { customerNumber: this.params["customerNumber"], sysRef: this.params["sysRef"] }, "MXP");
                });
                this.get("#/crm-devices/:accountNumber/:deviceId", function (context) {
                    load("crm-devices", context, { accountNumber: this.params["accountNumber"], deviceId: this.params["deviceId"] }, "CRM");
                });
                this.get("#/mxp-crm-comp-devices/:customerNumber", function (context) {
                    load("mxp-vs-crm-devices", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-contracts/:customerNumber", function (context) {
                    load("mxp-contracts", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-contracts/:customerNumber/:contractNumber", function (context) {
                    load("mxp-contracts", context, { customerNumber: this.params["customerNumber"], contractNumber: this.params["contractNumber"] }, "MXP");
                });
                this.get("#/mxp-leases/:customerNumber", function (context) {
                    load("mxp-leases", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-leases-by-leaseId/:leaseId", function (context) {
                    load("mxp-leases", context, { leaseId: this.params["leaseId"] }, "LEASE");
                });
                this.get("#/mxp-service-calls/:customerNumber", function (context) {
                    load("mxp-service-calls", context, { customerNumber: this.params["customerNumber"] }, "MXP");
                });
                this.get("#/mxp-service-calls/:customerNumber/:serviceNumber/:entryDate", function (context) {
                    load("mxp-service-calls", context, {
                        customerNumber: this.params["customerNumber"],
                        serviceNumber: this.params["serviceNumber"], entryDate: this.params["entryDate"]
                    }, "MXP");
                });
                this.get("#/crm-opportunities/:accountNumber/:oppNumber", function (context) {
                    load("crm-opportunities", context, { accountNumber: this.params["accountNumber"], oppNumber: this.params["oppNumber"] }, "CRM");
                });
                this.get("#/crm-opportunities/:accountNumber", function (context) {
                    load("crm-opportunities", context, { accountNumber: this.params["accountNumber"] }, "CRM");
                });
            }).run();
        }
    }
});