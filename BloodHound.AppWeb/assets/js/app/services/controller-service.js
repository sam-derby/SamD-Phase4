define(["controllers/search-controller", "controllers/mxp-home-controller",
    "controllers/crm-home-controller", "controllers/mxp-crm-accounts-controller",
    "controllers/mxp-contacts-controller", "controllers/crm-contacts-controller",
    "controllers/mxp-devices-controller", "controllers/crm-devices-controller",
    "controllers/mxp-vs-crm-devices-controller", "controllers/mxp-contracts-controller",
    "controllers/mxp-leases-controller", "controllers/mxp-service-calls-controller"],
    function (searchController, mxpHomeController, crmHomeController,
        mxpCrmAccountsController, mxpContactsController, crmContactsController,
        mxpDevicesController, crmDevicesController, mxpCrmCompController,
        mxpContractsController, mxpLeasesController, mxpServiceCallsController) {
        var getControllerFromName = function(controllerName) {
            switch (controllerName.toLowerCase()) {
                case "search":
                    return searchController;
                case "mxp-home":
                    return mxpHomeController;
                case "crm-home":
                    return crmHomeController;
                case "mxp-crm-accounts":
                    return mxpCrmAccountsController;
                case "mxp-contacts":
                    return mxpContactsController;
                case "crm-contacts":
                    return crmContactsController;
                case "mxp-devices":
                    return mxpDevicesController;
                case "crm-devices":
                    return crmDevicesController;
                case "mxp-vs-crm-devices":
                    return mxpCrmCompController;
                case "mxp-contracts":
                    return mxpContractsController;
                case "mxp-leases":
                    return mxpLeasesController;
                case "mxp-service-calls":
                    return mxpServiceCallsController;
            }
        };

    return {
       getController : getControllerFromName
    }
});