define(["utils/url-utils", "models/app-context", "models/sp-context", "ui/search-ui",
    "ui/recent-ui", "ui/nav-ui", "services/router-service"],
    function(urlUtils, appContext, spContext, search, recent, nav, routerService) {
        return {
            run: function () {
                spContext.siteUrl = urlUtils.getParameterByName("SPHostUrl");
                window.rootScope = {
                    context: appContext,
                    sharepointContext: spContext
                };
                search.init();
                nav.init();
                routerService.init();
                if (localStorage != undefined) {
                    var data = localStorage.getItem("bloodhound-recent-data");
                    if (data != undefined) {
                        var savedRecentData = $.parseJSON(data);
                        window.rootScope.context.recentSearches = savedRecentData;
                        if (window.rootScope.context.recentSearches && window.rootScope.context.recentSearches.length > 0) {
                            $("#recent-search-count").text(window.rootScope.context.recentSearches.length);
                        }
                    }
                }
                recent.init();
            }
        }
});