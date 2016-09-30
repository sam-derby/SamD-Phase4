define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var populate = function(data, routeData) {
            $('#crm-devices-table').dataTable({
                data: data,
                deferRender: true,
                "columns": [
                    { "data": "Name" },
                    { "data": "ItemNumber" },
                    { "data": "SerialNumber" },
                    { "data": "ParentAccountName" },
                    { "data": "Owner" },
                    { "data": "DeviceMifId" }
                ],
                "createdRow": function (row, value, index) {

                    $(row).id = value.SystemRef;
                    $(row).attr("data-device-id", value.DeviceMifId);
                    $(row).find('td').eq(3).addClass("onlyDesktop");
                    $(row).find('td').eq(4).addClass("onlyDesktop");
                    $(row).find('td').eq(5).addClass("hideAlways");
                }
            });
            if (routeData.deviceId != undefined && routeData.deviceId != null) {
                $(".dataTables_filter input[type='search']").val(routeData.deviceId).keyup();
            }
            $(".dataTables_filter input[type='search']").val("");
        };
        var loadData = function(routeData) {
            var dataUrl = "/CrmData/GetDevicesByAccountNumber?accountNumber=" + routeData.accountNumber;
            
            dataService.Get(dataUrl, null, function (data) {
                window.rootScope.context.crmDevices = data;
                populate(data, routeData);
                waitService.unblock();
            }, function (err) {
            });
            $("#crm-devices-table tbody").on("click", "tr", function () {     
                $("#crm-devices-table tr.selected").removeClass("selected");
                $(this).addClass("selected");
                var deviceId = $(this).attr("data-device-id");
                var deviceDataUrl = "/CrmData/GetDeviceByDeviceId?deviceId=" + deviceId;
                dataService.Get(deviceDataUrl, null, function (deviceData) {
                    var $container = $("#modal-content-container");
                    $("#modal-title").text(deviceData.ItemNumber);
                    $container.empty();
                    sammyContext.render("/assets/tmpl/partial/vw-crm-partial-device.template", { item: deviceData })
                       .appendTo("#modal-content-container")
                        .then(function () {
                            if (deviceData.SytemRef != undefined && deviceData.SytemRef != null) {
                                var crmDeviceDataUrl = "/CrmData/GetDeviceAndStatusBySysRef?systemRef=" + deviceData.SytemRef;
                                dataService.Get(crmDeviceDataUrl, null, function (crmDeviceData) {
                                    var crmStatus = crmDeviceData.CrmMxpStatus;
                                    var statusType = "alert-success";
                                    var statusMessage = "Device exists in both MXP and CRM";
                                    if (crmStatus === 50) {
                                        statusType = "alert-warning";
                                        statusMessage = "This device exists in MXP but not linked to this CRM account";
                                    }
                                    if (crmStatus === 40) {
                                        statusType = "alert-error";
                                        statusMessage = "This device does not exist in MXP";
                                    }
                                    $("#crm-status-notification").append("<div class='alert " + statusType + "'><strong>Crm Status </strong>" + statusMessage + "</div>");
                                }, function (err) { });
                            }
                        })
                       .then(function () {
                           $("#bloodhound-modal").modal("show");
                           if (deviceData.SytemRef.length > 0) {
                               $("#device-sys-ref-link").attr("href", "#/mxp-devices/" + deviceData.CustomerNumber + "/" + deviceData.SytemRef);
                               $("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                               $("#device-sys-ref-link").click(function () {
                                   $("#bloodhound-modal").modal("hide");
                               });
                           }
                           $("#device-parent-link").css("padding-left", "0px").css("color", "#337ab7");
                           $("#device-parent-link").click(function () {
                               $("#bloodhound-modal").modal("hide");
                           });
                          
                    });
                    }, function(err) {});
                });
        };
        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-crm-devices.template", {})
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
                $("#page-title").text("CRM Devices");
                loadPageTemplate(routeData);
            }
        }
    });