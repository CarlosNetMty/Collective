jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Header = {
        DataUrl: "Home/CurrentUser",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.User(data);
                self.ViewModel.WelcomeMessage = "Welcome {0}".format(data.IsLoggedIn ? self.ViewModel.UserName() : "back!");

                //if (!self.ViewModel.IsLoggedIn)
                //    Collective.Utils.Navigate("/");

                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);