jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.ArtistsDetail = {
        DataUrl: "Admin/ContributorDetail",
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
                    Collective.Utils.OnSave("Admin/Artists");
                };

                delete model.Save;
                delete model.Cancel;
                delete model.GoToDetail;

                Collective.Global.Post("/Admin/SaveContact", model, onSave);
            };

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Artist(data);
                self.ViewModel.GoToDetail = function (item) {

                    Collective.Utils.Navigate("{0}/{1}".format("Admin/Products", item.Id));
                }
                self.ViewModel.Cancel = function () {

                    Collective.Utils.Navigate("Admin/Artists");
                }
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