jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Setting = {
        DataUrl: "Admin/Configuration",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {

            //Initial set
            var self = this;
            self.View = control;

            function save() {
                
                var model = ko.toJS(self.ViewModel);
                var onSave = function () {
                    Collective.Utils.OnSave("Admin/Setting");
                };

                delete model.Save;
                Collective.Global.Post("/Admin/SaveSetting", model, onSave);
            };

            //menu initializarion
            function init(data) {

                self.ViewModel = new Collective.ViewModels.Settings(data);
                self.ViewModel.Save = save;

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

Collective.ViewModels.Settings = function (model) {

    // ViewModel
    var self = this;

    self.SettingId = ko.observable(model.SettingId);
    if (!model.Meta) model.Meta = {};

    self.Meta = {};
    self.Meta.Title = ko.observable(model.Meta.Title || "");
    self.Meta.Description = ko.observable(model.Meta.Description || "");
    self.Meta.Tags = ko.observable(model.Meta.Tags || "");
}