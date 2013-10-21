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
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, { id: 1 }, init);
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
    self.Active = ko.observable(model.Active);
    self.IsAdministratior = ko.observable(model.IsAdministratior);
    self.Name = ko.observable(model.Name);
    self.Email = ko.observable(model.Email);
    self.History = new Collective.ViewModels.Collection(model.History);
}