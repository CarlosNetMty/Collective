jQuery.namespace("Defero.ViewModels");

Defero.ViewModels.Sale = function (model) {

    // ViewModel 
    var self = this;
    // Properties (Values)
    self.Id = ko.observable(model.Id);
    self.Date = ko.observable(model.Date);

    self.SubTotal = ko.computed(function () {
        
        //Linq.js Implementation
        return 0.00;
    });

    self.Total = ko.observable(function () { return 0.00; });
    self.Details = ko.observableArray([]);
};