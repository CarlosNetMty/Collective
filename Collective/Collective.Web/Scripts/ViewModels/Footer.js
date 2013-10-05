jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Footer = function (model) {
    // ViewModel
    var self = this;

    //Header Items
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.Email = ko.observable();
    self.IsLoggedIn = ko.observable(false);
    self.IsAdministrator = ko.observable(false);
    //Language Specific
    self.CurrentLanguage = ko.observable(Collective.Global.CurrentLanguage);
    self.IsSpanish = ko.computed(function () { return self.CurrentLanguage() == "SPA"; });
    self.IsEnglish = ko.computed(function () { return self.CurrentLanguage() == "ENG"; });

     self.UserName = ko.computed(function () {
        return "{0} {1}".format(self.FirstName(), self.LastName());
    });
    self.ShoppingCart = new Collective.ViewModels.Sale();
    self.SubTotal = ko.computed(function () {
        return "Total: ${0}".format(self.ShoppingCart.SubTotal());
    });
    self.ItemCount = ko.computed(function () {
        return self.ShoppingCart.Details().length;
    });

    self.SearchText = ko.observable("");

    
}