define(["services/search-service","services/data-service","services/wait-service"],
    function (searchService,dataService,waitService) {
        var sammyContext;
        var loadMxpCustomers = function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-mxp-search-results", function(html) {
                var $html = $(html);
                sammyContext.$element().html($html);

                $("#datatable-mxp-cust-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                        { "data": "CustomerName" },
                        { "data": "CustomerNumber" },
                        { "data": "City" },
                        { "data": "PostCode" },
                        { "data": "Charge" },
                         { "data": "ChargeCustomerNumber" },
                        { "data": "MachineCount" }
                    ],
                    "createdRow": function (row, value, index) {
                        $(row).attr("id", value.CustomerNumber);
                        $(row).find('td').eq(1).addClass("onlyDesktop");
                        $(row).find('td').eq(2).addClass("onlyDesktop");
                        $(row).find('td').eq(3).addClass("onlyDesktop");
                        $(row).find('td').eq(4).addClass("onlyDesktop");
                        $(row).find('td').eq(5).addClass("onlyDesktop");
                    }
                });

                $("#datatable-mxp-cust-search-results tbody").on("click", "tr", function () {
                    var selectedId = $(this).attr("id");
                    document.location.href = "#/mxp-home/" + selectedId;
                });
                
                waitService.unblock();
            });
        };
        var loadCrmAccounts = function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-crm-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);
                $("#datatable-crm-cust-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                        { "data": "AccountName" },
                        {"data": "PostCode" },
                        { "data": "City" },
                        { "data": "OwnerName"},
                        { "data": "ActiveDeviceCount"},
                        {"data": "ParentAccountName" },
                        { "data": "LastActivityDate" },
                        { "data": "NextActivityDate"},
                         { "data": "ParentAccountId"},
                        { "data": "MxpCustomerNumber"}
                    ],
                    "createdRow": function (row, value, index) {
                         $(row).attr("id", value.AccountNumber);
                        $(row).find('td').eq(1).addClass("onlyDesktop");
                        $(row).find('td').eq(2).addClass("onlyDesktop");
                        $(row).find('td').eq(3).addClass("onlyDesktop");
                        $(row).find('td').eq(5).addClass("onlyDesktop");
                        $(row).find('td').eq(8).addClass("onlyDesktop");
                        $(row).find('td').eq(9).addClass("onlyDesktop");
                    }
                });
                $("#datatable-crm-cust-search-results tbody").on("click", "tr", function() {
                    var selectedId = $(this).attr("id");
                    document.location.href = "#/crm-home/" + selectedId;
                });
                waitService.unblock();
            });
        };
        var loadDevices = function (data) {
        var arrayData =[];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-devices-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);
                $("#search-devices-table").dataTable({
                        data: arrayData,
                    deferRender: true,
                    "columns": [
                    { "data": "SerialNumber" },
                    {"data": "Item" },
                    {"data": "ItemDescription1"},
                    { "data": "SystemRef"},
                    {"data": "PostCode"},
                    {"data": "SerialStatus"},
                    {"data": "SerialStatusDescription"},
                    { "data": "AltRef" },
                    { "data": "MxpCustomerName" },
                    { "data": "MxpCustomerNumber"}
                ],
                "createdRow": function(row, value, index) {
                        $(row).attr("id", value.MxpCustomerNumber);
                        $(row).attr("data-sys-ref", value.SystemRef);
                        $(row).find('td').eq(2).addClass("onlyDesktop");
                        $(row).find('td').eq(3).addClass("onlyDesktop");
                        $(row).find('td').eq(4).addClass("onlyDesktop");
                        $(row).find('td').eq(5).addClass("onlyDesktop");
                        $(row).find('td').eq(7).addClass("onlyDesktop");
                        $(row).find('td').eq(8).addClass("onlyDesktop");
                        $(row).find('td').eq(9).addClass("onlyDesktop");
                        $(row).find('td').eq(10).addClass("onlyDesktop");
                    }
            });
                    $("#search-devices-table tbody").on("click", "tr", function () {
                        var selectedId = $(this).attr("id");
                        var selectedSystemRef = $(this).attr("data-sys-ref");
                        document.location.href = "#/mxp-devices/" +selectedId + "/" + selectedSystemRef;
                        });

                waitService.unblock();
            });
        };
        var loadMxpContracts = function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-mxp-contracts-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);

                $("#datatable-mxp-contracts-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                        { "data": "ContractNumber" },
                        { "data": "Description" },
                        { "data": "NumberOfLines" },
                        { "data": "ContractStartDate" },
                        { "data": "ContractEndDate" },
                        { "data": "ChargeCustomerNumber" }
                    ],
                    "createdRow": function (row, value, index) {
                        $(row).attr("id", value.CustomerNumber);
                        $(row).attr("data-contract-number", value.ContractNumber);
                    }
                });

                $("#datatable-mxp-contracts-search-results tbody").on("click", "tr", function () {
                    var selectedId = $(this).attr("id");
                    var contractNumber = $(this).attr("data-contract-number");
                    document.location.href = "#/mxp-contracts/" + selectedId + "/" + contractNumber;
                });

                waitService.unblock();
            });
        };
        var loadMxpLeases= function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-mxp-leases-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);

                $("#datatable-mxp-leases-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                    { "data": "LeaseRef" },
                    { "data": "Funder" },
                    { "data": "Term" },
                    { "data": "StartedDate" },
                    { "data": "CalculatedEndDate" },
                    { "data": "Active" }
                    ],
                    "createdRow": function (row, value, index) {
                        $(row).attr("id", value.LeaseId);
                    }
                });

                $("#datatable-mxp-leases-search-results tbody").on("click", "tr", function () {
                    var selectedId = $(this).attr("id");
                    document.location.href = "#/mxp-devices-leased/" + selectedId;
                });

                waitService.unblock();
            });
        };
        var loadServiceCalls = function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-mxp-service-calls-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);

                $("#datatable-mxp-service-calls-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                    { "data": "ServiceNumber" },
                    { "data": "EntryDate" },
                    { "data": "SoStatus" },
                    { "data": "SoStatusDescription" },
                    { "data": "ItemNumber" },
                    { "data": "TechCode" },
                    { "data": "TechName" },
                    { "data": "CustomerNumber" },
                    { "data": "ChargeCustomerNumber" },
                    { "data": "ContractNumber" },
                    { "data": "ContractLine" },
                    { "data": "ServiceType" }
                    ],
                    "createdRow": function (row, value, index) {
                        $(row).attr("id", value.ServiceNumber);
                        $(row).attr("data-custnumber", value.CustomerNumber);
                        $(row).attr("data-entryDate", value.EntryDate);
                        $(row).find('td').eq(2).addClass("onlyDesktop");
                        $(row).find('td').eq(3).addClass("onlyDesktop");
                        $(row).find('td').eq(4).addClass("onlyDesktop");
                        $(row).find('td').eq(5).addClass("onlyDesktop");
                        $(row).find('td').eq(6).addClass("onlyDesktop");
                        $(row).find('td').eq(7).addClass("onlyDesktop");
                        $(row).find('td').eq(10).addClass("onlyDesktop");
                    }
                });

                $("#datatable-mxp-service-calls-search-results tbody").on("click", "tr", function () {
                    var selectedId = $(this).attr("id");
                    var entryDate = $(this).attr("data-entryDate");
                    var customerNumber = $(this).attr("data-custnumber");
                    document.location.href = "#/mxp-service-calls/" + customerNumber + "/" + selectedId + "/" + entryDate;
                });

                waitService.unblock();
            });
        };
        var loadOpportunities = function (data) {
            var arrayData = [];
            arrayData = data;
            dataService.LoadSearchResultsViewTemplate("vw-crm-opp-search-results", function (html) {
                var $html = $(html);
                sammyContext.$element().html($html);

                $("#datatable-crm-opp-search-results").dataTable({
                    data: arrayData,
                    deferRender: true,
                    "columns": [
                    { "data": "OpportunityNumber" },
                    { "data": "Topic" },
                    { "data": "PotentialCustomerName" },
                    { "data": "StatusCodeName" },
                    { "data": "OwnerIdName" },
                    { "data": "StateCodeName" },
                    { "data": "EstimatedCloseDate" },
                    { "data": "ActualCloseDate" }
                    ],
                    "createdRow": function (row, value, index) {
                        $(row).attr("id", value.OpportunityNumber);
                        $(row).attr("data-accountNumber", value.CustomerId);
                        $(row).find('td').eq(1).addClass("onlyDesktop");
                        $(row).find('td').eq(3).addClass("onlyDesktop");
                        $(row).find('td').eq(5).addClass("onlyDesktop");
                        $(row).find('td').eq(6).addClass("onlyDesktop");
                        $(row).find('td').eq(7).addClass("onlyDesktop");
                    }
                });

                $("#datatable-crm-opp-search-results tbody").on("click", "tr", function () {
                    var selectedId = $(this).attr("id");
                    var accountNumber = $(this).attr("data-accountNumber");
                    document.location.href = "#/crm-opportunities/" + accountNumber + "/" + selectedId;
                });

                waitService.unblock();
            });
        };
        return {
            load: function (context, routeData) {
                $("#page-desc").text("");
                sammyContext = context;
                $("#page-title").text("Search Results");
                var callBack = null;
                switch (routeData.filter.toLowerCase()) {
                    case "mxp-cust-no":
                    case "mxp-cust-name":
                        callBack = loadMxpCustomers;
                        break;
                    case "crm-cust-name":
                        callBack = loadCrmAccounts;
                        break;
                    case "dev-cust-no":
                    case "dev-sys-ref":
                    case "dev-serial-no":
                    case "dev-alt-ref":
                    case "dev-lease-id":
                        callBack = loadDevices;
                        break;
                    case "mxp-contract-number":
                        callBack = loadMxpContracts;
                        break;
                    case "mxp-lease-ref":
                        callBack = loadMxpLeases;
                        break;
                    case "mxp-service-no":
                        callBack = loadServiceCalls;
                        break;
                    case "crm-opp-no":
                        callBack = loadOpportunities;
                        break;
                }
                waitService.block();
                searchService.fetchResults(routeData, callBack);
            }
        }
    });
