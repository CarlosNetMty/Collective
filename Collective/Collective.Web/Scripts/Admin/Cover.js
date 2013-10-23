jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Cover = {
        DataUrl: "Home/Cover",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {

            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Collection(data);
                self.ViewModel.Remove = function (item) {

                    Collective.Global.Post("/Admin/RemoveBackground/", { id: item.Id }, function () {
                        Collective.Utils.Notify("Item updated!");
                    });
                    self.ViewModel.Items.remove(item);
                };
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);