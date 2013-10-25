jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.ProductsDetail = {
        DataUrl: "Admin/StockDetail",
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
                    Collective.Utils.OnSave("Admin/Products");
                };

                delete model.Save;
                delete model.Cancel;
                delete model.AvailableFrames;
                delete model.AvailableArtists;

                Collective.Global.Post("/Admin/SaveProduct", model, onSave);
            };


            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.ProductDetail(data);
                self.ViewModel.Cancel = function () {

                    Collective.Utils.Navigate("Admin/Products");
                };
                self.ViewModel.Save = save;
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

Collective.ViewModels.ProductDetail = function (model) {

    // ViewModel
    var self = this;

    self.ItemId = ko.observable(model.ItemId);
    self.ArtistId = ko.observable(model.ArtistId);
    self.AvailableArtists = ko.observableArray(model.AvailableArtists || []);

    self.Price = ko.observable(model.Price);
    self.Spanish = ko.observable(model.Spanish);
    self.English = ko.observable(model.English);

    self.Meta = {};
    self.Meta.Title = ko.observable(model.Meta.Title || "");
    self.Meta.Description = ko.observable(model.Meta.Description || "");
    self.Meta.Tags = ko.observable(model.Meta.Tags || "");
    
    self.ItemId = ko.observable(model.ItemId);
    self.PhotoURL = ko.observable(model.PhotoURL);
    self.UseAsCover = ko.observable(model.UseAsCover);
}