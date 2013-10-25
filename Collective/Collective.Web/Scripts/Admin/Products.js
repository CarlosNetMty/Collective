jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Products = {
        DataUrl: "Admin/Stock",
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
                self.ViewModel.GoToNew = function () {

                    Collective.Utils.Navigate("Admin/Products/0");
                };
                self.ViewModel.GoToDetail = function (item) {
                    var location = window.location;
                    var redirectTo = "{0}//{1}/{2}/{3}".format(location.protocol, location.host, "Admin/Products", item.Id);

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