define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var populate = function(data, routeData) {
            $('#mxp-leases-table').dataTable({
                data: data,
                deferRender: true,
                "columns": [
                    { "data": "LeaseRef" },
                    { "data": "Funder" },
                    { "data": "Term" },
                    { "data": "StartedDate" },
                    { "data": "CalculatedEndDate" },
                    { "data": "Active"}
                ],
                "createdRow": function (row, value, index) {
                    $(row).attr("id",value.LeaseId);
                    $(row).attr("data-leaseId", value.LeaseId);
                    if (routeData.leaseId != undefined && routeData.leaseId.length > 0)
                        $(row).click();
                }
            });
            if (routeData.LeaseId != undefined && routeData.LeaseId != null) {
                $(".dataTables_filter input[type='search']").val(routeData.LeaseId).keyup();
            }
            //var table = document.getElementById("mxp-leases-table");
            //var rows = table.rows;
            //if (routeData.leaseId != undefined && routeData.leaseId.length > 0) {
            //    $.each(rows, function (index, row) {
            //        if (row.id === routeData.leaseId) {
            //            row.click();
            //            return;
            //        }
            //    });
            //} else {
            //    if (rows.length > 1) {
            //        var firstRow = rows[1];
            //        firstRow.click();
            //    }
            //}
            //$(".dataTables_filter input[type='search']").val("");
        };
        var loadData = function(routeData) {
            var dataUrl = "/MxpData/GetLeasesByCustomerNumber?customerNumber=" + routeData.customerNumber;
            if (routeData.leaseId != undefined && routeData.leaseId.length > 0)
                dataUrl = "/MxpData/GetLeaseListByLeaseId?leaseId=" + routeData.leaseId;
            dataService.Get(dataUrl, null, function (data) {
                    populate(data, routeData);
                    waitService.unblock();
                 }, function (err) {
            });
            $("#mxp-leases-table tbody").on("click", "tr", function () {
                //$("#mxp-leases-table tr.selected").removeClass("selected");
                //$(this).addClass("selected");
                var leaseId = $(this).attr("data-leaseId");
                document.location.href = "#/mxp-devices-leased/" + routeData.customerNumber + "/" + leaseId + "/true";
                //var leaseDataUrl = "/MxpData/GetLeasesByLeaseId?leaseId=" + leaseId;
                //dataService.Get(leaseDataUrl, null, function (leaseData) {
                //    var $container = $("#modal-content-container");
                //    $("#modal-title").text(leaseData.LeaseRef);
                //    $container.empty();
                //    sammyContext.render("/assets/tmpl/partial/vw-mxp-partial-lease.template", { item: leaseData })
                //        .appendTo("#modal-content-container");
                //    $("#bloodhound-modal").modal("show");
               // }, function(err) {});
            });
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-leases.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    waitService.block();
                    loadData(routeData);
                });
        };
        return {
            
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Leases");
                loadPageTemplate(routeData);
            }
        }
    });