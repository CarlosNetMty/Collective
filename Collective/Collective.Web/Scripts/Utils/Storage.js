jQuery.namespace("Collective.Storage");

Collective.Storage.Get = function (key, defaultValue) {

    return $.jStorage.get(key, defaultValue);
}

Collective.Storage.Set = function (key, value) {

    return $.jStorage.set(key, value);
}
