define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var loadData = function (routeData) {
            var dataUrl = "/MxpData/GetContractHeadersByCustomerNumber?customerNumber=" + routeData.customerNumber;
            dataService.Get(dataUrl, null, function(data) {
                $.each(data, function(index, value) {
                    sammyContext.render("/assets/tmpl/partial/table-rows/vw-mxp-header-contracts-table-row.template", { rowId: index + 1, item: value })
                        .appendTo("#mxp-contract-headers-table tbody")
                        .then(function () {
                            var table = document.getElementById("mxp-contract-headers-table");
                            var rows = table.rows;
                            if (routeData.contractNumber != undefined && routeData.contractNumber.length > 0) {
                                $.each(rows, function (index, row) {
                                    if (row.id === routeData.contractNumber) {
                                        row.click();
                                        return;
                                    }
                                });
                            } else {
                                if (rows.length > 1) {
                                    var firstRow = rows[1];
                                    firstRow.click();
                                }
                            }
                        });
                });
               
                $("#mxp-contract-headers-table tbody").on("click", "tr", function () {
                    $("#mxp-contract-headers-table tr.selected").removeClass("selected");
                    $(this).addClass("selected");
                    $("#mxp-contract-lines-table tbody").empty();
                    var contractId = $(this).attr("id");
                    var linesDataUrl = "/MxpData/GetContractLinesByContractNumberAndCustomerNumber?contractNumber=" + contractId + "&customerNumber=" + routeData.customerNumber;
                   waitService.block();
                    $("#contract-lines-container").show();
                    dataService.Get(linesDataUrl, null, function (lineData) {
                        $('#mxp-contract-lines-table').dataTable({
                            data: lineData,
                            bDestroy: true,
                            deferRender: true,
                            "columns": [
                                { "data": "ContractNumber" },
                                { "data": "Description" },
                                { "data": "LineNumber" },
                                { "data": "ItemNumber" },
                                { "data": "ItemDescription" },
                                { "data": "CustomerNumber" },
                                { "data": "SerialNumber" }
                            ],
                            "createdRow": function (row, value, index) {
                                $(row).attr("data-contract-number", value.ContractNumber);
                                $(row).attr("data-customer-number", value.CustomerNumber);
                                $(row).attr("data-line-number", value.LineNumber);
                                var itemText = $(row).find('td').eq(4).text();
                                if (itemText.length > 30) {
                                    $(row).find("td").eq(4).text(itemText.substr(0, 30) + "...");
                                }
                                var lineNumberText = $(row).find('td').eq(2).text();
                                $(row).find("td").eq(2).text(Math.round(parseFloat(lineNumberText)));
                            }
                        });
                        
                        $("#mxp-contract-lines-table tbody").on("click", "tr", function () {
                            $("#mxp-contract-lines-table tr.selected").removeClass("selected");
                            $(this).addClass("selected");
                            var contractNumber = $(this).attr("data-contract-number");
                            var customerNumber = $(this).attr("data-customer-number");
                            var lineNumber = $(this).attr("data-line-number");
                            var contractLineDataUrl = "/MxpData/GetContractLineByCustomerNumberContractNumberAndLineNumber?customerNumber=" + customerNumber + "&contractNumber=" + contractNumber + "&lineNumber=" + lineNumber;
                            dataService.Get(contractLineDataUrl, null, function (lineData) {
                                var $container = $("#modal-content-container");
                                $("#modal-title").text(lineData.ItemNumber);
                                $container.empty();
                                sammyContext.render("/assets/tmpl/partial/vw-mxp-partial-contract.template", { item: lineData })
                                   .appendTo("#modal-content-container")
                                   .then(function () {
                                       var lineNumberText = $("#mxp-line-number").text();
                                       $("#mxp-line-number").text(Math.round(parseFloat(lineNumberText)));
                                       $("#mxp-contract-cust-no").click(function () {
                                           $("#bloodhound-modal").modal("hide");
                                       });
                                       var contractLineCategoryDataUrl = "/MxpData/GetContractLineCategoriesByContractNumberAndLineNumber?contractNumber=" + contractNumber + "&lineNumber=" + lineNumber;
                                       dataService.Get(contractLineCategoryDataUrl, null, function(lineCategories) {
                                           $.each(lineCategories, function (index, value) {
                                               if (value.Flag === true) {
                                                   value.Flag = "Yes";
                                                   value.Label = "label-success";
                                               } else {
                                                   value.Flag = "No";
                                                   value.Label = "label-danger";
                                               }
                                               sammyContext.render("/assets/tmpl/partial/table-rows/vw-mxp-contract-category-table-row.template", { item: value })
                                                   .appendTo("#mxp-contracts-category-table tbody")
                                                   .then(
                                                       
                                                   );
                                           });
                                           if (lineData.SystemRef.length > 0) {
                                               // $("#device-sys-ref-link").attr("href", "#/mxp-devices/" + lineData.CustomerNumber + "/" + lineData.SystemRef);
                                               //$("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                                               $("#device-sys-ref-link").click(function () {
                                                   $("#bloodhound-modal").modal("hide");
                                                   $('#bloodhound-modal').on('hidden.bs.modal', function () {
                                                       var deviceDataUrl = "/MxpData/GetDeviceAndStatusBySysRef?systemRef=" + lineData.SystemRef;
                                                       dataService.Get(deviceDataUrl, null, function (deviceData) {
                                                           var $container = $("#modal-content-container");
                                                           $("#modal-title").text(deviceData.Item);
                                                           $container.empty();
                                                           sammyContext.render("/assets/tmpl/partial/vw-mxp-partial-device.template", { item: deviceData })
                                                               .appendTo("#modal-content-container")
                                                               .then(function () {
                                                                   var crmStatus = deviceData.CrmMxpStatus;
                                                                   var statusType = "alert-success";
                                                                   var statusMessage = "Device exists in both MXP and CRM";
                                                                   if (crmStatus === 20) {
                                                                       statusType = "alert-warning";
                                                                       statusMessage = "This device exists in CRM but not linked to this MXP account";
                                                                   }
                                                                   if (crmStatus === 30) {
                                                                       statusType = "alert-error";
                                                                       statusMessage = "This device edoes not exist in CRM";
                                                                   }
                                                                   $("#crm-status-notification").append("<div class='alert " + statusType + "'><strong>Crm Status </strong>" + statusMessage + "</div>");

                                                                   if (deviceData.SystemRef.length > 0) {
                                                                       var crmDeviceDataUrl = "/CrmData/GetDeviceBySysRef?systemRef=" + deviceData.SystemRef;
                                                                       dataService.Get(crmDeviceDataUrl, null, function (crmDeviceData) {
                                                                           $("#device-sys-ref-link").attr("href", "#/crm-devices/" + crmDeviceData.ParentAccountId + "/" + crmDeviceData.DeviceMifId);
                                                                           $("#device-sys-ref-link").click(function () {
                                                                               $("#bloodhound-modal").modal("hide");
                                                                           });
                                                                           $("#bloodhound-modal").modal("show");
                                                                           $("#bloodhound-modal").off('hidden.bs.modal');
                                                                       }, function (err) { });
                                                                   } else {
                                                                       $("#bloodhound-modal").modal("show");
                                                                       $("#bloodhound-modal").off('hidden.bs.modal');
                                                                   }
                                                                   $("#mxp-dev-cust-no").click(function () {
                                                                       $("#bloodhound-modal").modal("hide");
                                                                   });

                                                               });
                                                       }, function (err) { });

                                                   });
                                               });

                                               $("#bloodhound-modal").modal("show");
                                           }
                                           else { $("#bloodhound-modal").modal("show"); }
                                       }, function (err) { });
                                      
                                   });
                            }, function (err) { });
                        });
                        waitService.unblock();
                    });
                });
                waitService.unblock();
            });
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-contracts.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    loadData(routeData);
                    $("#contract-lines-container").hide();
                });
        };
        return {
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Contracts");
                loadPageTemplate(routeData);
            }
        }
});