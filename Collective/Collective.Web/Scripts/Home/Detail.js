jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Detail = {
        DataUrl: "Home/Product",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control, args) {
            //Initial set
            var self = this;
            self.View = control;

            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            //initialization callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.DetailOfProduct(data);

                self.ViewModel.SetSize = function (item, event) {

                    $(event.currentTarget).parent().toggle();
                    self.ViewModel.SelectedSize(item);
                };

                self.ViewModel.SetFrame = function (item, event) {

                    $(event.currentTarget).parent().toggle();
                    self.ViewModel.SelectedFrame(item);
                };

                self.ViewModel.NavigateToArtist = function () {
                    var location = window.location;
                    window.location = "{0}//{1}/Home/Gallery/?search={2}".format(location.protocol, location.host, self.ViewModel.ArtistName.replace(" ",  ""));
                };

                self.ViewModel.ShowOptions = function (item, event) { $(event.currentTarget).siblings(".selectOptions").toggle(); }

                //var headTag = $("head");
                //headTag.append($("<meta name='{0}' content='{1}'>".format("name", self.ViewModel.Meta.Title())));
                //headTag.append($("<meta name='{0}' content='{1}'>".format("description", self.ViewModel.Meta.Description())));
                //headTag.append($("<meta name='{0}' content='{1}'>".format("tags", self.ViewModel.Meta.Tags())));

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

Collective.ViewModels.DetailOfProduct = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.AvailableSizes = ko.observableArray(Collective.Utils.NullOrEmpty(model.AvailableSizes, true));
    self.AvailableFrames = ko.observableArray(Collective.Utils.NullOrEmpty(model.AvailableFrames, true));
    self.Related = ko.observableArray(Collective.Utils.NullOrEmpty(model.Related, true));
   
    self.SelectedSize = ko.observable(self.AvailableSizes()[0] || {});
    self.SelectedSizeName = ko.computed(function () {
        return self.SelectedSize().Name || "Default";
    });

    self.SelectedFrame = ko.observable(self.AvailableFrames()[0] || {});
    self.SelectedFrameName = ko.computed(function () {
        return self.SelectedFrame().Name || "Default";
    });


    self.TotalText = "Total: ${0}".format(model.Price);

    self.Name = model.Name;
    self.ArtistId = model.ArtistId;
    self.ArtistName = model.ArtistName;
    self.ArtistEnglish = model.ArtistEnglish;
    self.ArtistSpanish = model.ArtistSpanish;
    self.Price = model.Price;
    self.PhotoUrl = model.PhotoUrl;
    self.Code = model.Code;

    self.Meta = {};
    self.Meta.Title = ko.observable(model.Meta.Title || "");
    self.Meta.Description = ko.observable(model.Meta.Description || "");
    self.Meta.Tags = ko.observable(model.Meta.Tags || "");
}