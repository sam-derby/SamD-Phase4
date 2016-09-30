define([], function () {
    var recentDisplay = false;
    return {
        showRecent: function () {
           recentDisplay = true;
           var recent = window.rootScope.context.recentSearches;
           $("#recent-search-list").empty();
            $("#recent-search-list").append($("<li class='notification-header'><h5 style='color: #000'>Last 10 Recent Searches</h5></li>"));
           _.each(recent, function(searchItem) {
               var name = searchItem.name;
               var id = searchItem.id;
               var contextType = searchItem.type;
               var html = "";
               if (contextType === "MXP") {
                   html = "<li><a href='#/mxp-home/" + id + "' class='recent-search-btn'><i class='fa fa-square green-font'></i><span class='text'> MXP: " + name +"</span></a></li>";
               } else {
                   html = "<li><a href='#/crm-home/" + id + "' class='recent-search-btn'><i class='fa fa-square yellow-font'></i><span class='text'> CRM: " + name + "</span></a></li>";
               }
               $("#recent-search-list").append($(html));
           });
        },
        hideRecent: function () {
            if (recentDisplay === true) {
                $("#recent-search").click();
                recentDisplay = false;
            }
        }
    }
});


