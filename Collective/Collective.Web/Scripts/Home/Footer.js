jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Footer = {
        DataUrl: "Home/Footer",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control, args) {

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

                self.View.find("input").keypress(function (event) {
                    if (event.key === "Enter")
                    {
                        var location = window.location;
                        window.location = "{0}//{1}/Home/Gallery/?search={2}".format(location.protocol, location.host, this.value);
                    }
                })
                
                self.ViewModel.SearchText(args.search);
                ko.applyBindings(self.ViewModel, control.context);
            }
            //Get server data (if needed)
            Collective.Global.Get(self, {}, init);
            //Custom Controls
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);