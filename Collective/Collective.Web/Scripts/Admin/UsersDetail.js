jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.UserDetail = {
        DataUrl: "Admin/CredentialDetail",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {

            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.UserDetail(data);
                self.ViewModel.ActiveCaption = ko.computed(function () {

                    return self.ViewModel.Active() ? "Deactivate" : "Activate";
                });
                self.ViewModel.Cancel = function () {

                    Collective.Utils.Navigate("Admin/Users");
                }
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, { id: Collective.Utils.CurrentObject() }, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.UserDetail = function (model) {
    // ViewModel
    var self = this;

    //Current Element
    self.UserID = ko.observable(model.UserID);
    self.CurrentID = ko.computed(function () {
        return Number(self.UserID() || 0).padLeft(5, "0");
    });

    self.Active = ko.observable(model.Active);
        
    self.IsAdministratior = ko.observable(model.IsAdministratior);
    self.Name = ko.observable(model.Name);
    self.Email = ko.observable(model.Email);
    self.History = new Collective.ViewModels.Collection(model.History);

    self.HasHistory = ko.computed(function () {
        return self.History.Items.length;
    });
}