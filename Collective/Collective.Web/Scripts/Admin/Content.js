jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Content = {
        DataUrl: "Admin/StaticContent",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {

            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Content(data);
                ko.applyBindings(self.ViewModel, control.context);

                self.View.find("textarea").jqte();
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

Collective.ViewModels.Content = function (model) {
    // ViewModel
    var self = this;

    //Current Element
    self.About = ko.observable(model.About);
    self.Conditions = ko.observable(model.Conditions);
}