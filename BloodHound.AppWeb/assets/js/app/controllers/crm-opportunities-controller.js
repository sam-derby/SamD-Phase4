define(["services/data-service","services/wait-service", "ui/date-range-ui"],
    function (dataService,waitService, dateRangeUi) {
        var sammyContext;
        var populate = function (data, routeData) {
             $('#crm-opportunities-table').dataTable({
                data: data,
                destroy: true,
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
             var table = document.getElementById("crm-opportunities-table");
             var rows = table.rows;
             if (rows.length > 1) {
                var firstRow = rows[1];
                firstRow.click();
             }
        };
        var loadData = function (routeData, startDate, endDate) {
            waitService.block();
            var dataUrl = "/CrmData/GetOpportunities?accountNumber=" + routeData.accountNumber + "&state=" + state + "&startDate=" + startDate.format('DD-MM-YYYY') + "&endDate=" + endDate.format('DD-MM-YYYY');
            if (routeData.oppNumber != undefined && routeData.oppNumber != null) {
                dataUrl = "/CrmData/GetOpportunitiesWithOppNumber?accountNumber=" + routeData.accountNumber + "&oppNumber=" + routeData.oppNumber;
            }
            dataService.Get(dataUrl, null, function (data) {
                    populate(data, routeData);
                    waitService.unblock();
                 }, function (err) {
            });
            $("#crm-opportunities-table tbody").on("click", "tr", function () {
                $("#crm-opportunities-table tr.selected").removeClass("selected");
                $(this).addClass("selected");
                var oppNumber = $(this).attr("id");
                var accountNumber = $(this).attr("data-accountnumber");
                var oppDataUrl = "/CrmData/GetOpportunity?oppNumber=" + oppNumber;
                dataService.Get(oppDataUrl, null, function (oppData) {
                    var $container = $("#modal-content-container");
                    $("#modal-title").text(oppData.OppNumber);
                    $container.empty();
                    sammyContext.render("/assets/tmpl/partial/vw-crm-partial-opportunity.template", { item: oppData })
                        .appendTo("#modal-content-container")
                    .then(function () {
                        $("#bloodhound-modal").modal("show");
                        //if (serviceData.SystemRef.length > 0) {
                        //    $("#device-sys-ref-link").attr("href", "#/mxp-devices/" + routeData.customerNumber + "/" + serviceData.SystemRef);
                        //    $("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                        //    $("#device-sys-ref-link").click(function () {
                        //        $("#bloodhound-modal").modal("hide");
                        //    });
                        //}
                    });
                }, function(err) {});
            });
        };

        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-crm-opportunities.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    if (routeData.oppNumber != undefined && routeData.oppNumber != null) {
                        var startDate = moment(routeData.createdDate);
                        var endDate = moment(routeData.createdDate);
                        dateRangeUi.init("#opportunity-date-range",
                           function (start, end) {
                               loadData(routeData, start, end);
                           },startDate,endDate);
                    } else {
                        dateRangeUi.init("#opportunity-date-range",
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
                $("#page-title").text("CRM Opportunities");
                loadPageTemplate(routeData);
            }
        }
    });