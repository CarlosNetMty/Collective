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

                self.ViewModel.IsHomePage = function () {

                    return Collective.Utils.IsHomePage();
                };

                self.View.find("input").keypress(function (event) {
                    if (event.key === "Enter")
                    {
                        var location = window.location;
                        window.location = "{0}//{1}/Home/Gallery/?search={2}".format(location.protocol, location.host, this.value);
                    }
                })

                self.ViewModel.GoToConditions = function () {
                    var location = window.location;
                    window.location = "{0}//{1}{2}".format(location.protocol, location.host, "/Home/Conditions");
                }
                
                self.ViewModel.SearchText(args.search);
                ko.applyBindings(self.ViewModel, control.context);

                Collective.Global.CurrentUser();
            }
            //Get server data (if needed)
            Collective.Global.Get(self, {}, init);
            //Custom Controls
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Footer = function (model) {
    // ViewModel
    var self = this;

    //Language Specific
    self.CurrentLanguage = ko.observable(Collective.Global.CurrentLanguage);
    self.IsSpanish = ko.computed(function () { return self.CurrentLanguage() == "SPA"; });
    self.IsEnglish = ko.computed(function () { return self.CurrentLanguage() == "ENG"; });

    self.SearchText = ko.observable("");
    self.ShowProduction = ko.computed(function () {
        return Collective.Global.ProductionEnabled;
    });
}