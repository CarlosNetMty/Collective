﻿jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Login = {
        DataUrl: "/Home/Login",
        Server: false,
        ViewModel: {},
        View: {},
        Open: function() { if(this.View) $(this.View).dialog(); },
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Login();
                
                //cancel function
                var cancel = function ()
                {
                    $(self.View).dialog("close");
                    self.ViewModel.Username("");
                    self.ViewModel.Password("");
                    self.ViewModel.Register.Username("");
                    self.ViewModel.Register.Password("");
                    self.ViewModel.Register.ConfirmPassword("");
                    self.ViewModel.Register.Email("");
                };

                //set cancel
                self.ViewModel.Cancel = cancel;
                self.ViewModel.Register.Cancel = cancel;

                //actions
                self.ViewModel.RequestLogin = function () { };
                self.ViewModel.Register.RequestRegister = function () { };

                ko.applyBindings(self.ViewModel, control.context);
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

Collective.ViewModels.Login = function () {
    // ViewModel
    var self = this;
    
    self.Username = ko.observable();
    self.Password = ko.observable();

    self.Register  = new Collective.ViewModels.Register();
}