jQuery.namespace("Collective.Global");

Collective.Global.CurrentLanguage = Collective.Storage.Get("CurrentLanguage", "ENG");
Collective.Global.LanguageCallbacks = $.Callbacks();

Collective.Global.Init = function (view) {

    Collective.Translations.Set(view);
};

Collective.Global.Get = function (module, data, callback) {

    if (!module.Server)
        callback();
    else
        $.ajax({
            url: module.DataUrl,
            data: data,
            type: "get",
            contentType: "application/json",
            dataType: "json",
            success: function(result) {
                if ($.isFunction(callback))
                    callback(result);
            }
        });
};

Collective.Global.Load = function (url, data, viewModel) {
    
    if ($.isFunction(viewModel))
        Defero.Global.Get(url, data, function (result) {
            return viewModel(result);
        });

    return false;
};