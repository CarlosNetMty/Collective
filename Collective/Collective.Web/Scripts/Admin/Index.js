jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Index = {
        DataUrl: "/Admin/Production",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {

            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Collection(data);
                self.ViewModel.GoToDetail = function (item) {
                    var location = window.location;
                    var redirectTo = "{0}//{1}/{2}/{3}".format(location.protocol, location.host, "Admin/Index", item.Id);

                    window.location = redirectTo;
                }
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);