jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.ArtistsDetail = {
        DataUrl: "Admin/ContributorDetail",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Artist(data);
                self.ViewModel.GoToDetail = function (item) {
                    var location = window.location;
                    var redirectTo = "{0}//{1}/{2}/{3}".format(location.protocol, location.host, "Admin/Products", item.Id);

                    window.location = redirectTo;
                }
                self.ViewModel.Cancel = function () {
                    var location = window.location;
                    var redirectTo = "{0}//{1}/{2}".format(location.protocol, location.host, "Admin/Artists");

                    window.location = redirectTo;
                }
                self.ViewModel.Save = function () {
                    debugger;
                }
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, { id: 1 }, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);