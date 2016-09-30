define(function () {
    return {
        recentSearches: [],
        crmMxpCustomerNumber: "",
        mxpDevices: [],
        crmDevices: [],
        nameCtrl: null,
        currentMxpCutomer: {},
        heartbeat: null,
        addToRecent: function (data) {
            var exists = _.find(this.recentSearches, function (item) { return item.id === data.id });
            if (!exists) {
                this.recentSearches.unshift(data);
                this.recentSearches = _.first(this.recentSearches, 10);
                localStorage.setItem("bloodhound-recent-data", JSON.stringify(this.recentSearches));
                $("#recent-search-count").text(this.recentSearches.length);
            }
        }
    }
});
