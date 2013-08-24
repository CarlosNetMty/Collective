﻿jQuery.namespace("Collective.Home");

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
                viewModel.Items.push({ title: Collective.Translations.Get("Galleries"), url: "#" });
                viewModel.Items.push({ title: Collective.Translations.Get("About"), url: "#" });
                viewModel.Items.push({ title: Collective.Translations.Get("Contact"), url: "#" });
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
                    alert("Navigate to: {0}".format(menuItem.title));
                    //TODO: Impement Navigation
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
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model.Items, true));
}