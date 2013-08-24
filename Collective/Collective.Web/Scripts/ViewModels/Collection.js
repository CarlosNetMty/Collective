jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Collection = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model, true));    
}