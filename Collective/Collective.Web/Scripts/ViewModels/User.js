jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.User = function (model) {

    // ViewModel 
    var self = this;
    // Properties (Values)
    self.IsLogged = ko.observable(model.IsLogged);
    self.FirstName = ko.observable(model.FirstName);
    self.LastName = ko.observable(model.LastName);
    self.IsAdministrator = ko.observable(model.IsAdministrator);
    self.Name = ko.observable(model.Name);
    //Computed
    self.UserName = ko.computed(function () {

        if (self.FirstName())
            return "{1}, {0}".format(self.FirstName(), self.LastName());

        return self.Name();
    });
}