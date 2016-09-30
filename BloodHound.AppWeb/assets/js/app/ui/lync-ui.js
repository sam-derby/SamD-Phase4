define([],
    function () {
        return {
            init: function(b) {
                var c = null;
                try {
                    c = document.getElementById(b);
                    if (!Boolean(c) && Boolean(navigator.mimeTypes) && navigator.mimeTypes[b] && navigator.mimeTypes[b].enabledPlugin) {
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
        }
});