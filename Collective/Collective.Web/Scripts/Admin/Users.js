jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Users = {
        DataUrl: "Admin/Credentials",
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

                    Collective.Utils.Navigate("{0}/{1}".format("Admin/Users", item.Id));
                }
                self.ViewModel.GoToNew = function () {

                    Collective.Utils.Navigate("Admin/Users/0");
                };

                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);