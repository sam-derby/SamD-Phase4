define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var populate = function(data, routeData) {
            $('#mxp-devices-table').dataTable({
                data: data,
                deferRender: true,
                "columns": [
                    { "data": "AltRef" },
                    { "data": "Item" },
                    { "data": "ItemDescription1" },
                    { "data": "ItemDescription2" },
                    { "data": "MxpCustomerNumber" },
                    { "data": "MxpCustomerName" },
                    { "data": "PostCode" },
                    { "data": "SerialNumber" },
                    { "data": "SerialStatus" },
                    { "data": "SerialStatusDescription" },
                    { "data": "SystemRef" }
                ],
                "createdRow": function(row, value, index) {
                    $(row).id = value.SystemRef;
                    $(row).attr("data-sys-ref", value.SystemRef);
                    $(row).find('td').eq(0).addClass("onlyDesktop");
                    $(row).find('td').eq(2).addClass("onlyDesktop");
                    var itemDesc = row.children[2].innerHTML;
                    if (itemDesc.length > 20)
                        row.children[2].innerHTML = itemDesc.substr(0, 20) + "...";
                    $(row).find('td').eq(3).addClass("onlyDesktop hideAlways");
                    $(row).find('td').eq(4).addClass("onlyDesktop");
                    $(row).find('td').eq(6).addClass("onlyDesktop");
                    $(row).find('td').eq(7).addClass("onlyDesktop");
                    $(row).find('td').eq(8).addClass("onlyDesktop");
                    $(row).find('td').eq(9).addClass("onlyDesktop");
                }
            });
            if (routeData.sysRef != undefined && routeData.sysRef != null) {
                $(".dataTables_filter input[type='search']").val(routeData.sysRef).keyup();
            }
            $(".dataTables_filter input[type='search']").val("");
        };
        var loadData = function (routeData) {
            var dataUrl = "/MxpData/GetDevicesByCustomerNumber?custNumber=" + routeData.customerNumber;
            if (routeData.leaseId != undefined && routeData.leaseId.length > 0 && (routeData.customerNumber == undefined || routeData.customerNumber.length === 0)) {
                dataUrl = "/MxpData/GetDevicesByLeaseId?leaseId=" + routeData.leaseId;
                $("#btnCompareDevices").hide();
            }
            if (routeData.devbylease === "true") {
                dataUrl = "/MxpData/GetDevicesByLeaseId?leaseId=" + routeData.leaseId;
                $("#btnCompareDevices").hide();
                $("#page-title").text("MXP Devices By Lease");
            }
            dataService.Get(dataUrl, null, function (data) {
                window.rootScope.context.mxpDevices = data;
                populate(data, routeData);
                waitService.unblock();
            }, function (err) {
            });
            $("#mxp-devices-table tbody").on("click", "tr", function () {
                $("#mxp-devices-table tr.selected").removeClass("selected");
                $(this).addClass("selected");
                var sysRef = $(this).attr("data-sys-ref");
                var deviceDataUrl = "/MxpData/GetDeviceAndStatusBySysRef?systemRef=" + sysRef;
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
                                statusMessage = "This device does not exist in CRM";
                            }
                            $("#crm-status-notification").append("<div class='alert " + statusType + "'><strong>Crm Status </strong>" + statusMessage + "</div>");
                            if (deviceData.OppNumber == null || deviceData.OppNumber.length === 0) {
                                $("#mxp-device-opp-number").hide();
                            }
                            if (deviceData.SystemRef.length > 0) {
                                var crmDeviceDataUrl = "/CrmData/GetDeviceBySysRef?systemRef=" + deviceData.SystemRef;
                                dataService.Get(crmDeviceDataUrl, null, function(crmDeviceData) {
                                    $("#device-sys-ref-link").attr("href", "#/crm-devices/" + crmDeviceData.ParentAccountId + "/" + crmDeviceData.DeviceMifId);
                                    $("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                                    $("#device-sys-ref-link").click(function() {
                                        $("#bloodhound-modal").modal("hide");
                                    });
                                    $("#bloodhound-modal").modal("show");

                                }, function(err) {});
                            } else {
                                $("#bloodhound-modal").modal("show");
                            }
                            $("#mxp-dev-cust-no").click(function() {
                                $("#bloodhound-modal").modal("hide");
                            });
                    });
                }, function (err) { });

            });
            
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-devices.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    $("#btnCompareDevices").attr("href", "#/mxp-crm-comp-devices/" + routeData.customerNumber);
                    loadData(routeData);
                });
        };
        return {
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("MXP Devices");
                loadPageTemplate(routeData);
            }
        }
    });