jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Contact = {
        DataUrl: "Home/Login",
        Server: false,
        ViewModel: {},
        View: {},
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
                self.ViewModel = new Collective.ViewModels.Contact();
                self.ViewModel.Send = function ()
                {
                    var data =
                    {
                        name: self.ViewModel.Name(),
                        email: self.ViewModel.Email(),
                        phone: self.ViewModel.Phone(),
                        message: self.ViewModel.Message()
                    };

                    Collective.Global.Post("/Home/SendMessage/", data, function () {

                        alert("Message Sent");
                        self.ViewModel.Name("");
                        self.ViewModel.Email("");
                        self.ViewModel.Phone("");
                        self.ViewModel.Message("");
                    });
                };

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

Collective.ViewModels.Contact = function () {
    // ViewModel
    var self = this;
    
    self.Name = ko.observable();
    self.Email = ko.observable();
    self.Phone = ko.observable();
    self.Message = ko.observable();
}
