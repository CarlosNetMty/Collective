jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Artist = function (model) {

    // ViewModel 
    var self = this;
    // Properties (Values)
    self.Name = ko.observable(model.Name);
    self.SpanishBio = ko.observable(model.SpanishBio);
    self.EnglishBio = ko.observable(model.EnglishBio);

    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model.Stock, true));
}