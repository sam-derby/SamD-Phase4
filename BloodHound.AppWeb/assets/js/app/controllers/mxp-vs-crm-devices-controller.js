define(["services/data-service","services/wait-service"],
    function (dataService,waitService) {
        var sammyContext;
        var populateMxpData = function(data) {
            for (var i = 0; i < data.length; i++) {
                var foundItem = _.findWhere(window.rootScope.context.crmDevices, { SystemRef: data[i].SystemRef });
                var rowHtml = $("<tr data-sys-ref='" + data[i].SystemRef + "'><td>" + data[i].Item + "</td><td>" + data[i].SerialNumber + "</td><td>" + data[i].SystemRef + "</td></tr>");
                if (foundItem == null)
                    $(rowHtml).addClass("alert-danger");
                else
                    $(rowHtml).addClass("alert-success");
               $("#mxp-devices-table tbody").append(rowHtml);
            }
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
                                statusMessage = "This device edoes not exist in CRM";
                            }
                            $("#crm-status-notification").append("<div class='alert " + statusType + "'><strong>Crm Status </strong>" + statusMessage + "</div>");
                            $("#bloodhound-modal").modal("show");
                            if (deviceData.SystemRef.length > 0) {
                                var crmDeviceDataUrl = "/CrmData/GetDeviceBySysRef?systemRef=" + deviceData.SystemRef;
                                dataService.Get(crmDeviceDataUrl, null, function (crmDeviceData) {
                                    $("#device-sys-ref-link").attr("href", "#/crm-devices/" + crmDeviceData.ParentAccountId + "/" + crmDeviceData.DeviceMifId);
                                    $("#device-sys-ref-link").css("padding-left", "0px").css("color", "#337ab7");
                                    $("#device-sys-ref-link").click(function () {
                                        $("#bloodhound-modal").modal("hide");
                                    });

                                }, function (err) { });
                            }
                            $("#mxp-dev-cust-no").click(function () {
                                $("#bloodhound-modal").modal("hide");
                            });
                        });
                }, function (err) { });

            });
        };
        var populateCrmData = function (data) {
            for (var i = 0; i < data.length; i++) {
                var foundItem = _.findWhere(window.rootScope.context.mxpDevices, { SystemRef: data[i].SystemRef });
                var rowHtml = $("<tr data-device-id='" + data[i].DeviceMifId + "'><td>" + data[i].Name + "</td><td>" + data[i].SerialNumber + "</td><td>" + data[i].SystemRef + "</td></tr>");
                if (foundItem == null)
                    $(rowHtml).addClass("alert-danger");
                else
                    $(rowHtml).addClass("alert-success");
                $("#crm-devices-table tbody").append(rowHtml);
            }
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
        var loadData = function (routeData) {
            var mxpDataUrl = "/MxpData/GetDevicesByCustomerNumber?custNumber=" + routeData.customerNumber;
            var crmDataUrl = "/CrmData/GetCrmDevicesByMxpCustomerNumber?customerNumber=" + routeData.customerNumber;

            dataService.Get(mxpDataUrl, null, function (mxpData) {
                window.rootScope.context.mxpDevices = mxpData;
                dataService.Get(crmDataUrl, null, function (crmData) {
                        window.rootScope.context.crmDevices = crmData;
                        populateMxpData(window.rootScope.context.mxpDevices);
                        populateCrmData(window.rootScope.context.crmDevices);
                    waitService.unblock();
                }, function (err) {
                    });
                }, function (err) {
            });
          
            
        };

        var loadPageTemplate = function (routeData) {
            sammyContext.render("/assets/tmpl/page/vw-mxp-crm-comp-devices.template", {})
                .appendTo(sammyContext.$element())
                .then(function () {
                    loadData(routeData);
                });
        };
        return {
            
            load: function (context, routeData) {
                waitService.block();
                sammyContext = context;
                $("#page-title").text("Compare MXP & CRM Devices");
                loadPageTemplate(routeData);
            }
        }
    });