jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Footer = {
        DataUrl: "Home/Footer",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control) {

            var self = this;
            self.View = control;

            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Footer({});

                self.ViewModel.ChangeLanguage = function () {
                    var langItem = arguments[1].currentTarget.textContent;

                    Collective.Global.CurrentLanguage = langItem.toUpperCase();
                    this.CurrentLanguage(langItem.toUpperCase());
                    Collective.Global.LanguageCallbacks.fire();
                };

                ko.applyBindings(self.ViewModel, control.context);
            }
            //Get server data (if needed)
            Collective.Global.Get(self, {}, init);
            //Custom Controls
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);