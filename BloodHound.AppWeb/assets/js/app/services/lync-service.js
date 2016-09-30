define([], function () {
    function addUser(userName, elementId, parentElement, ctrlId) {
        var userElementId = elementId;
        $(parentElement).append("<div id='" + userElementId + "'>.</div>");
        $("#" + userElementId).css("height", "10px");
        $("#" + userElementId).css("width", "10px");
        $("#" + userElementId).css("color", "#fff");
        $("#" + userElementId).css("position", "relative");
        $("#" + userElementId).css("bottom", "-4px");
        $("#" + userElementId).css("margin-left", "5px");
        $("#" + userElementId).hover(function() {
            if (!window.rootScope.context.nameCtrls[ctrlId]) {
                return;
            }

            var eLeft = $("#" + userElementId).offset().left;
            var x = eLeft - $(window).scrollLeft();

            var eTop = $("#" + userElementId).offset().top;
            var y = eTop - $(window).scrollTop();

            window.rootScope.context.nameCtrls[ctrlId].ShowOOUI(userName, 0, x, y);
        }, function() {
            if (!window.rootScope.context.nameCtrls[ctrlId]) {
                return;
            }
            window.rootScope.context.nameCtrls[ctrlId].HideOOUI();
        });

        if (window.rootScope.context.nameCtrls[ctrlId]) {
            window.rootScope.context.nameCtrls[ctrlId].GetStatus(userName, userElementId);
        }
    }

    function detectIE() {
        var ua = window.navigator.userAgent;
        var msie = ua.indexOf('MSIE ');
        if (msie > 0) {
            // IE 10 or older => return version number
            return parseInt(ua.substring(msie + 5, ua.indexOf('.', msie)), 10);
        }
        var trident = ua.indexOf('Trident/');
        if (trident > 0) {
            // IE 11 => return version number
            var rv = ua.indexOf('rv:');
            return parseInt(ua.substring(rv + 3, ua.indexOf('.', rv)), 10);
        }
        var edge = ua.indexOf('Edge/');
        if (edge > 0) {
            // IE 12 => return version number
            return parseInt(ua.substring(edge + 5, ua.indexOf('.', edge)), 10);
        }

        // other browser
        return false;
    }

    function getLyncPresenceString(status) {

        switch (status) {
            case 0:
                return 'available';
                break;
            case 1:
                return 'offline';
                break;
            case 2:
            case 4:
            case 16:
                return 'away';
                break;
            case 3:
            case 5:
                return 'inacall';
                break;
            case 6:
            case 7:
            case 8:
            case 10:
                return 'busy';
                break;
            case 9:
            case 15:
                return 'donotdisturb';
                break;
            default:
                return '';
        }
    }

    function attachLyncPresenceChangeEvent(ctrlId) {
        if (window.rootScope == undefined || window.rootScope == null)
            return;
        if (!window.rootScope.context.nameCtrls) {
            return;
        }
        window.rootScope.context.nameCtrls[ctrlId].OnStatusChange = onLyncPresenceStatusChange;
    }

    function onLyncPresenceStatusChange(userName, status, id) {
        var presenceClass = getLyncPresenceString(status);
        var userElement = $("#" + id);
        removePresenceClasses(userElement);
        userElement.addClass(presenceClass);

    }

    function removePresenceClasses(jqueryObj) {
        jqueryObj.removeClass("available");
        jqueryObj.removeClass("offline");
        jqueryObj.removeClass("away");
        jqueryObj.removeClass("busy");
        jqueryObj.removeClass("donotdisturb");
        jqueryObj.removeClass("inacall");
    }


    function isSupportedNpApiBrowserOnWin() {
        return true;
    }

    function isNpapiOnWinPluginInstalled(a) {
        return Boolean(navigator.mimeTypes) && navigator.mimeTypes[a] && navigator.mimeTypes[a].enabledPlugin;
    }

    function createNpApiOnWindowsPlugin(b) {
        var c = null;
        if (isSupportedNpApiBrowserOnWin())
            try {
                c = document.getElementById(b);
                if (!Boolean(c) && isNpapiOnWinPluginInstalled(b)) {
                    var a = document.createElement("object");
                    a.id = b;
                    a.type = b;
                    a.width = "0";
                    a.height = "0";
                    a.style.setProperty("visibility", "hidden", "");
                    document.body.appendChild(a);
                    c = document.getElementById(b);
                }
            } catch (d) {
                c = null;
            }
        return c;
    }

    function initialiseControl(ctrlId) {
        try {
            if ((!detectIE()))
                window.rootScope.context.nameCtrls[ctrlId] = createNpApiOnWindowsPlugin("application/x-sharepoint-uc");
            else {
                window.rootScope.context.nameCtrls[ctrlId] = new ActiveXObject("Name.NameCtrl");
            }
            //if (!window.ActiveXObject) {
            //    window.rootScope.context.nameCtrls[ctrlId] = new ActiveXObject("Name.NameCtrl");

            //} else {
            //    window.rootScope.context.nameCtrls[ctrlId] = createNpApiOnWindowsPlugin("application/x-sharepoint-uc");
            //}
            attachLyncPresenceChangeEvent(ctrlId);
        }
        catch (ex) { }
    }

    function resetControls() {
        window.rootScope.context.nameCtrls = {}
    }

    return {
        attachPresenceChangedEvent: attachLyncPresenceChangeEvent,
        addUser: addUser,
        initialiseControl: initialiseControl,
        resetControls: resetControls
    }
});

