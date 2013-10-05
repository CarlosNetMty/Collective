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

                    var pathData = window.location.pathname.split("/");
                    var pathSections = [];

                    $.each(pathData, function (index, item) {
                        if (item) pathSections.push(item);
                    });

                    if (!pathSections.length) return true;
                    if (pathSections.length == 1 && pathSections[0] == "Home") return true;
                    if (pathSections.length == 2 && pathSections[0] == "Home" && pathSections[1] == "Index") return true;

                    return false;
                };

                self.View.find("input").keypress(function (event) {
                    if (event.key === "Enter")
                    {
                        var location = window.location;
                        window.location = "{0}//{1}/Home/Gallery/?search={2}".format(location.protocol, location.host, this.value);
                    }
                })

                self.View.find("[data-key='Login']").click(function () { Collective.Home.Login.Open(); });
                self.View.find("[data-key='Register']").click(function () { Collective.Home.Register.Open(); });
                self.View.find("[data-key='LoginAndRegister']").click(function () { Collective.Home.Login.Open(); });

                self.ViewModel.GoToAdmin = function ()
                {
                    var location = window.location;
                    window.location = "{0}//{1}{2}".format(location.protocol, location.host, "/Admin");
                }

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