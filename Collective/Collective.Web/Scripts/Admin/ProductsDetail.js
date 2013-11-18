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
                delete model.AvailableTags;
                delete model.AvailableSizes;
                                
                model.SelectedTags = model.SelectedTags.join();
                model.SelectedSizes = model.SelectedSizes.join();
                model.SelectedFrames = model.SelectedFrames.join();

                Collective.Global.Post("/Admin/SaveProduct", model, onSave);
            };

            function setOnChange(key, collection)
            {
                //Sets Initial Load
                $.each(self.View.find("div[data-key={0}] input".format(key)), function (index, item)
                {
                    var control = $(item);
                    control.attr("checked", collection.indexOf(parseInt(control.attr("id"))) >= 0);
                });

                //Sets Tag Change
                self.View.find("div[data-key={0}] input".format(key)).bind("change", function ()
                {
                    var controlValue = parseInt(this.attributes["id"].nodeValue);
                    var alreadyAdded = collection.indexOf(controlValue) >= 0;

                    if (this.checked)
                        collection.push(controlValue);
                    else
                        collection.remove(controlValue);
                });
            }

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.ProductDetail(data);
                self.ViewModel.Cancel = function () {

                    Collective.Utils.Navigate("Admin/Products");
                };

                self.ViewModel.Save = save;
                ko.applyBindings(self.ViewModel, control.context);

                setOnChange("Tags", self.ViewModel.SelectedTags);
                setOnChange("Sizes", self.ViewModel.SelectedSizes);
                setOnChange("Frames", self.ViewModel.SelectedFrames);
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
    self.Code = ko.observable(model.Code);

    if (!model.Meta) model.Meta = {};
    
    self.Meta = {};
    self.Meta.Title = ko.observable(model.Meta.Title || "");
    self.Meta.Description = ko.observable(model.Meta.Description || "");
    self.Meta.Tags = ko.observable(model.Meta.Tags || "");
    
    self.UseAsBackground = ko.observable(model.UseAsCover);
    self.ItemId = ko.observable(model.ItemId);
    self.PhotoURL = ko.observable(model.PhotoURL);
    self.PhotoReview = ko.computed(function () {

        if(!self.PhotoURL())
            return "/Images/c7_image_not_available.jpg";

        return "/Photos/{0}".format(self.PhotoURL());
    });

    self.SelectedTags = ko.observableArray(model.Tags);
    self.SelectedFrames = ko.observableArray(model.Frames);
    self.SelectedSizes = ko.observableArray(model.Sizes);

    self.AvailableTags = ko.observableArray(model.AvailableTags || []);
    self.AvailableFrames = ko.observableArray(model.AvailableFrames || []);
    self.AvailableSizes = ko.observableArray(model.AvailableSizes || []);
}