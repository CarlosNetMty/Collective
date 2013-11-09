jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Index = {
        DataUrl: "Home/Cover",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this
                body = $(document).children();
            self.View = control;

            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            var nextIndex = 0;
            function setNewDataAsCurrent() {
                var element = self.ViewModel.Items()[nextIndex];
                //New Contol Set
                self.ViewModel.CurrentName(element.Name);
                self.ViewModel.CurrentImageURL(element.PhotoUrl);
                self.ViewModel.Artist(element.Artist);
                self.ViewModel.Id(element.Id);
                self.ViewModel.Price(element.Price || 0);
                //Set background
                body.css("background-image", 'url("..{0}")'.format(self.ViewModel.CurrentImageURL()));
                //Set new index
                nextIndex++;
                if (nextIndex >= self.ViewModel.Items().length)
                    nextIndex = 0;
            }

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Index(data);

                self.ViewModel.GoToDetail = function () {
                    Collective.Utils.Navigate("/Home/Detail/?id={0}".format(self.ViewModel.Id()));
                };

                setNewDataAsCurrent();
                $(document).everyTime(15000, setNewDataAsCurrent);
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

Collective.ViewModels.Index = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model, true));

    //Current Element
    self.CurrentName = ko.observable();
    self.CurrentImageURL = ko.observable();
    self.Artist = ko.observable();
    self.Price = ko.observable();
    self.Id = ko.observable();
}