jQuery.namespace("Collective.Admin");

(function () {
    Collective.Admin.Sidebar = {
        DataUrl: "Admin/Side",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //menu initializarion
            function init(data) {

                var elements = [
                    { title: "Users", url: "/Admin/Users" },
                    { title: "Products", url: "/Admin/Products" },
                    { title: "Artists", url: "/Admin/Artists" },
                    { title: "Settings", url: "/Admin/Setting" },
                    { title: "Cover Images", url: "/Admin/Cover" },
                    { title: "Static Content", url: "/Admin/Content" }
                ];

                if (Collective.Global.ProductionEnabled)
                    elements.push({ title: "Production Report", url: "/Admin" });

                self.ViewModel = new Collective.ViewModels.AdminSidebar(elements);
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

Collective.ViewModels.AdminSidebar = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model, true));
}