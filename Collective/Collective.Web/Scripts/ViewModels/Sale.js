jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Sale = function (model) {

    // ViewModel 
    var self = this;
    // Properties (Values)
    self.Date = ko.observable(new Date());
    self.Total = ko.observable(function () { return 0.00; });
    self.Details = ko.observableArray([]);
    //Computed
    self.SubTotal = ko.computed(function () {
        
        //Linq.js Implementation
        var subTotal = $.Enumerable.From(self.Details())
            .Sum(function (item) { return item.Price; });

        return subTotal.toFixed(2);
    });
};

Collective.ViewModels.SaleItem = function (model) { 

    // ViewModel 
    var self = this;
    // Properties (Values)
    self.Price = model.Price;
    self.Description = model.Description;
    self.ImageUrl = model.ImageUrl;

};