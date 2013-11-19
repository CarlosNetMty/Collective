jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Login = {
        DataUrl: "Home/Login",
        Server: false,
        ViewModel: {},
        View: {},
        Open: function() { if(this.View) $(this.View).toggle(); },
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            function showRegister() {
                self.View.find("[data-key='Popup']").toggle();
            }

            function handleAuthentication(response) {
                if (response && response.IsAuthenticated) {
                    Collective.Global.CurrentUser(response.User);
                }
            }

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Login();
                
                //cancel function
                var cancel = function ()
                {
                    self.View.find("[data-key='Popup']").hide();
                    self.ViewModel.Username("");
                    self.ViewModel.Password("");
                    self.ViewModel.Register.Username("");
                    self.ViewModel.Register.Password("");
                    self.ViewModel.Register.ConfirmPassword("");
                    self.ViewModel.Register.Email("");
                };

                self.ViewModel.ShowRegister = showRegister;

                //set cancel
                self.ViewModel.Cancel = cancel;
                self.ViewModel.Register.Cancel = cancel;

                self.ViewModel.IsHomePage = function ()
                {
                    return Collective.Utils.IsHomePage();
                }

                //******* LOGOUT ********
                self.ViewModel.LogOut = function () {

                    Collective.Global.Post("/Home/LogOut/", {}, function () {
                        Collective.Utils.Navigate("/");
                    });
                };

                //******* LOGIN ********
                self.ViewModel.RequestLogin = function () {
                    var data = {
                        email: this.Username(),
                        password: $.md5(this.Password())
                    };

                    Collective.Global.Post("/Home/LogIn/", data, handleAuthentication);
                };

                //******* REGISTER ********
                self.ViewModel.Register.RequestRegister = function () {
                    var data = {
                        name: this.Register.Username(),
                        email: this.Register.Email(),
                        password: $.md5(this.Register.Password()),
                    };

                    Collective.Global.Post("/Home/Register/", data, handleAuthentication);
                };

                self.View.find(".loginregion input").bind("keypress", function (event) {
                    if (event.key == "Enter" && self.ViewModel.Username() && self.ViewModel.Password())
                        self.ViewModel.RequestLogin();
                });

                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
            //Get current user
            Collective.Global.CurrentUser();
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Login = function () {
    // ViewModel
    var self = this;
    
    self.Username = ko.observable();
    self.Password = ko.observable();

    self.Register = new Collective.ViewModels.Register();

    //Header Items
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.Email = ko.observable();
    self.IsLoggedIn = ko.observable(false);
    self.IsAdministrator = ko.observable(false);

    self.UserName = ko.computed(function () {
        return "{0} {1}".format(self.FirstName(), self.LastName());
    });

    self.ShoppingCart = new Collective.ViewModels.Sale();
    self.SubTotal = ko.computed(function () {
        return "Total: ${0}".format(self.ShoppingCart.SubTotal());
    });
    self.ItemCount = ko.computed(function () {
        return self.ShoppingCart.Details().length;
    });

    self.ShowProduction = ko.computed(function () {
        return Collective.Global.ProductionEnabled;
    });
}

Collective.ViewModels.Register = function () {
    // ViewModel
    var self = this;

    self.Username = ko.observable();
    self.Password = ko.observable();
    self.ConfirmPassword = ko.observable();
    self.Email = ko.observable();
}