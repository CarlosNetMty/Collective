jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Register = {
        DataUrl: "/Home/Register",
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
                self.ViewModel = new Collective.ViewModels.Register();
                
                //cancel function
                var cancel = function ()
                {
                    $(self.View).dialog("close");
                    self.ViewModel.Username("");
                    self.ViewModel.Password("");
                    self.ViewModel.ConfirmPassword("");
                    self.ViewModel.Email("");
                };

                //set cancel
                self.ViewModel.Cancel = cancel;

                //actions
                self.ViewModel.RequestRegister = function () { };

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

Collective.ViewModels.Register = function () {
    // ViewModel
    var self = this;

    self.Username = ko.observable();
    self.Password = ko.observable();
    self.ConfirmPassword = ko.observable();
    self.Email = ko.observable();
}