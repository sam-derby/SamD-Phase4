define(["services/recent-service"],
    function (recent) {
        return {
            init: function() {
                $("#recent-search").click(function() {
                    recent.showRecent();
                });
            }
        }
});