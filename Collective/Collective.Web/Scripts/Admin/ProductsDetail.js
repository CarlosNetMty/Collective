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

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.ProductDetail(data);
                self.ViewModel.Cancel = function () {
                    Collective.Utils.Navigate("Admin/Products");
                };
                self.ViewModel.Save = function () {
                    debugger;
                };

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

    self.ArtistId = ko.observable(model.ArtistId);
    self.AvailableArtists = ko.observableArray(model.AvailableArtists || []);

    self.Price = ko.observable(model.Price);
    self.Spanish = ko.observable(model.Spanish);
    self.English = ko.observable(model.English);

    self.Meta = ko.observable(model.Meta || {});
    self.MTitle = ko.computed(function () { return self.Meta().Title || ""; });
    self.MDescription = ko.computed(function () { return self.Meta().Description || ""; });
    self.MTags = ko.computed(function () { return self.Meta().Tags || ""; });

    self.PhotoURL = ko.observable(model.PhotoURL);
    self.UseAsCover = ko.observable(model.UseAsCover);
}