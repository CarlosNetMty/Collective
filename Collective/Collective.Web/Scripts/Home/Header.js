jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Header = {
        DataUrl: "Home/Header",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;
            //Menu load
            function loadMenuItems(viewModel)
            {
                viewModel.Items.removeAll();
                viewModel.Items.push({ title: Collective.Translations.Get("Galleries"), url: "/Home/Gallery" });
                viewModel.Items.push({ title: Collective.Translations.Get("About"), url: "/Home/About" });
                viewModel.Items.push({ title: Collective.Translations.Get("Contact"), url: "/Home/Contact" });
            }
            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
                loadMenuItems(Collective.Home.Header.ViewModel);
            });
            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Header({});
                //Actions
                self.ViewModel.Navigate = function (menuItem) {
                    var location = window.location;
                    window.location = "{0}//{1}{2}".format(location.protocol, location.host, menuItem.url);
                }

                self.ViewModel.GoToAdmin = function () {
                    Collective.Utils.Navigate("Admin");
                }

                self.ViewModel.GoToHome = function () {
                    Collective.Utils.Navigate("");
                }

                ko.applyBindings(self.ViewModel, control.context);
                loadMenuItems(self.ViewModel);
            }
            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Header = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.IsAdministrator = ko.observable(true);
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model.Items, true));
}