jQuery.namespace("Defero.Sales");

(function() {
    Defero.Sales.Index = {
        DataUrl: "Sales/Get",
        ViewModel: {},
        Sidebar: {},
        View: {},
        Load: function (control) {
            
            Defero.Global.SetView(this, control);
            
            function init(data) {
                this.ViewModel = new Defero.ViewModels.Sale(data);                
                ko.applyBindings(this.ViewModel, control.context);
            }
            
            Defero.Global.Get(this.DataUrl, { }, init);
            Defero.Global.Init(this.View);
        }
    };
})(jQuery);