jQuery.namespace("Collective.Sales");

(function() {
    Collective.Sales.Index = {
        DataUrl: "Sales/Get",
        ViewModel: {},
        Sidebar: {},
        View: {},
        Load: function (control) {
            
            Collective.Global.SetView(this, control);
            
            function init(data) {
                this.ViewModel = new Collective.ViewModels.Sale(data);
                ko.applyBindings(this.ViewModel, control.context);
            }
            
            Collective.Global.Get(this.DataUrl, {}, init);
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);