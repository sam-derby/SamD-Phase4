define([],function () {
    return {
        block: function () {
            $("html").addClass("loading");
        },
        unblock: function () {
            $("html").removeClass("loading");
        }
    }
});

