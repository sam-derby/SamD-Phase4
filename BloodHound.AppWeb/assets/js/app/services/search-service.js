define(["services/data-service"],function (dataService) {

    var performRequest = function(url, callBack) {
        dataService.Get(url,null, callBack);
    };

    var getData = function(routeData, callBack) {
        var filter = routeData.filter;
        var value = routeData.value;
        var url = "";
        switch (filter.toLowerCase()) {
            case "mxp-cust-no":
                url = "/MxpData/SearchByCustomerNumber?custNumber=" + value;
                break;
            case "mxp-cust-name":
                url = "/MxpData/SearchByCustomerName?custName=" + value;
                break;
            case "crm-cust-name":
                url = "/CrmData/SearchByCustomerName?accountName=" + value;
                break;
            case "dev-cust-no":
                url = "/DeviceSearchData/SearchByCustomerNumber?custNumber=" + value;
                break;
            case "dev-sys-ref":
                url = "/DeviceSearchData/SearchBySystemRef?sysRef=" + value;
                break;
            case "dev-serial-no":
                url = "/DeviceSearchData/SearchBySerialNumber?serialNumber=" + value;
                break;
            case "dev-alt-ref":
                url = "/DeviceSearchData/SearchByAlternativeReference?altRef=" + value;
                break;
            case "dev-lease-id":
                url = "/DeviceSearchData/SearchByLeaseId?leaseId=" + value;
                break;
            case "mxp-contract-number":
                url = "/MxpData/SearchContractsByContractNumber?contractNumber=" + value;
                break;
            case "mxp-lease-ref":
                url = "/MxpData/SearchLeasesByLeaseRef?leaseRef=" + value;
                break;
            case "mxp-service-no":
                url = "/MxpData/SearchServiceCallsByServiceNumber?serviceNumber=" + value;
                break;
            case "crm-opp-no":
                url = "/CrmData/SearchOpportunitiesByOpportunityNumber?oppNumber=" + value;
                break;
        }
        performRequest(url, callBack);
    };

    return {
        fetchResults: getData
    }
});

