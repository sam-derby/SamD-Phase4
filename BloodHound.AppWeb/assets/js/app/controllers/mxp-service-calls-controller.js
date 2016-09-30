define(["services/data-service","services/wait-service", "ui/date-range-ui"],
    function (dataService,waitService, dateRangeUi) {
        var sammyContext;
        var populate = function (data, routeData) {
             $('#mxp-service-calls-table').dataTable({
                data: data,
                destroy: true,
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
                    $(row).attr("data-custnumber", routeData.customerNumber);
                    $(row).find('td').eq(2).addClass("onlyDesktop");
                    $(row).find('td').eq(3).addClass("onlyDesktop");
                    $(row).find('td').eq(4).addClass("onlyDesktop");
                    $(row).find('td').eq(5).addClass("onlyDesktop");
                    $(row).find('td').eq(6).addClass("onlyDesktop");
                    $(row).find('td').eq(7).addClass("onlyDesktop");
                    $(row).find('td').eq(10).addClass("onlyDesktop");
                }
             });
             var table = document.getElementById("mxp-service-calls-table");
             var rows = table.rows;
             if (rows.length > 1) {
                var firstRow = rows[1];
                firstRow.click();
             }
        };
        var loadData = function (routeData, startDate, endDate) {
            waitService.block();
            var dataUrl = "/MxpData/GetServiceCalls?customerNumber=" + routeData.customerNumber + "&startDate=" + startDate.format('DD-MM-YYYY') + "&endDate=" + endDate.format('DD-MM-YYYY');
            if (routeData.serviceNumber != undefined && routeData.serviceNumber != null) {
                dataUrl = "/MxpData/GetServiceCallsWithServiceNumber?customerNumber=" + routeData.customerNumber + "&serviceNumber=" + routeData.serviceNumber;
            }
            dataService.Get(dataUrl, null, function (data) {
                    populate(data, routeData);
                    waitService.unblock();
                 }, function (err) {
            });
            $("#mxp-service-calls-table tbody").on("click", "tr", function () {
                $("#mxp-service-calls-table tr.selected").removeClass("selected");
                $(this).addClass("selected");
                var serviceNumber = $(this).attr("id");
                var customerNumber = $(this).attr("data-custnumber");
                var serviceDataUrl = "/MxpData/GetServiceCall?customerNumber=" + customerNumber + "&serviceNumber=" + serviceNumber;
                dataService.Get(serviceDataUrl, null, function (serviceData) {
                    var $container = $("#modal-content-container");
                    $("#modal-title").text(serviceData.ServiceNumber);
                    $container.empty();
                    sammyContext.render("/assets/tmpl/partial/vw-mxp-partial-service-call.template", { item: serviceData })
                        .appendTo("#modal-content-container")
                    .then(function () {
                        $("#bloodhound-modal").modal("show");
                        if (serviceData.SystemRef.length > 0) {
                            $("#device-sys-ref-link").attr("href", "#/mxp-devices/" + routeData.customerNumber + "/" + serviceData.SystemRef);
                            $("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                            $("#device-sys-ref-link").click(function () {
                                $("#bloodhound-modal").modal("hide");
                            });
                        }
                    });
                }, function(err) {});
            });
        };

        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-service-calls.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    if (routeData.serviceNumber != undefined && routeData.serviceNumber != null) {
                        var startDate = moment(routeData.entryDate);
                        var endDate = moment(routeData.entryDate);
                        dateRangeUi.init("#service-call-date-range",
                           function (start, end) {
                               loadData(routeData, start, end);
                           },startDate,endDate);
                    } else {
                        dateRangeUi.init("#service-call-date-range",
                            function(start, end) {
                                loadData(routeData, start, end);
                            }, moment().subtract("days", 7), moment());
                    }
                    loadData(routeData, moment().subtract("days", 7), moment());
                    waitService.unblock();
                });
        };
        return {
            
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Service Calls");
                loadPageTemplate(routeData);
            }
        }
    });