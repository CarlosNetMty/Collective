jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Gallery = {
        DataUrl: "Home/Products",
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
                self.ViewModel = new Collective.ViewModels.Gallery(data);
                self.View.find(".fancybox").fancybox({ maxWidth: 450, maxHeight: 500, padding: 50 });

                //Initial isotope setup
                var $container = self.View.find("#container");
                $container.imagesLoaded(function () {
                    $container.isotope({ masonry: { columnWidth: 110, gutterWidth: 0 } });
                });

                //Changes the current filter value
                self.ViewModel.SetValue = function (item, event)
                {
                    //Initializes isotope
                    $container.isotope({ filter: item.Name });
                    //Hides the filter selection box
                    $(event.currentTarget).parent().toggle();
                    //Sets the current filter value in the ViewModel
                    self.ViewModel.CurrentValue(item.Text);
                };
                
                //Shows the current filters box
                self.ViewModel.ShowOptions = function(item, event) { $(event.currentTarget).siblings(".selectOptions").toggle(); }
                //Changes the current filter group
                self.ViewModel.ChangeFilter = function (newFilter) {

                    self.ViewModel.CurrentFilter(newFilter);
                    self.ViewModel.CurrentValue("All");
                    $container.isotope({ filter: "*" });
                };
                //Sets the current filters depending of the filter group
                self.ViewModel.CurrentFilter.subscribe(function (value)
                {
                    self.ViewModel.Filters(self.ViewModel[value]());
                    self.ViewModel.CurrentFilterDescription(self.ViewModel.DescriptionOfFilters[value]);
                });

                //Sets initial filter values
                self.ViewModel.CurrentFilter("Artist");
                self.ViewModel.CurrentValue("All");

                self.ViewModel.GoToDetail = function (item)
                {
                    var location = window.location;
                    window.location = "{0}//{1}/Home/Detail/?id={2}".format(location.protocol, location.host, item.Id);
                }

                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, { search: args.search }, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Gallery = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model.Items, true));
    //Filters
    self.CurrentFilter = ko.observable();
    self.CurrentValue = ko.observable();

    self.FilterTypes = ["Artist", "Theme", "Format"];
    self.CurrentFilterDescription = ko.observable();
    self.DescriptionOfFilters =
    {
        Artist: "Artist related. In the Contemporary Art category you can discover up-and-coming artist who have recently entered the Art Market and have impressed COLECTIVA with their innovative concepts. Their works are usually displayed in local galleries and museums. Their works are usually displayed in local galleries and museums.",
        Theme: "Themes related. In the Contemporary Art category you can discover up-and-coming artist who have recently entered the Art Market and have impressed COLECTIVA with their innovative concepts. Their works are usually displayed in local galleries and museums. Their works are usually displayed in local galleries and museums.",
        Format: "Format related. In the Contemporary Art category you can discover up-and-coming artist who have recently entered the Art Market and have impressed COLECTIVA with their innovative concepts. Their works are usually displayed in local galleries and museums. Their works are usually displayed in local galleries and museums."
    };

    self.Filters = ko.observableArray([]);
    self.Artist = ko.observableArray(Collective.Utils.NullOrEmpty(model.Artists, true));
    self.Theme = ko.observableArray(Collective.Utils.NullOrEmpty(model.Themes, true));
    self.Format = ko.observableArray(Collective.Utils.NullOrEmpty(model.Formats, true));

    function setTextToFilterCollection(collection)
    {
        $.each(collection, function ()
        {
            if (arguments[1].Text) {
                arguments[1].Text = arguments[1].Name == "*" ? "All" : arguments[1].Name;
                arguments[1].Name = arguments[1].Name == "*" ? "*" : ".{0}".format(arguments[1].Name.replace(" ", ""));
            }
        });
    }

    setTextToFilterCollection(self.Artist());
    setTextToFilterCollection(self.Theme());
    setTextToFilterCollection(self.Format());
}