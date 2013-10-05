//jQuery LIKE
String.prototype.format = String.prototype.format = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};

//Module LIKE
jQuery.namespace("Collective.Utils");

Collective.Utils.Settings =
{
    //DataServerFormat: "http://localhost/Collective/{0}/"
    DataServerFormat: "http://localhost:54693/{0}"
};

Collective.Utils.FormatDataURL = function (dataUrl)
{
    return Collective.Utils.Settings.DataServerFormat.format(dataUrl);
};

Collective.Utils.NullOrEmpty = function (value, isCollection) {
    if (isCollection)
        return value != null && value != undefined && value.length > 0 ? value : [];
    else
        return value != null && value != undefined ? value : {};
}

$(document).ready(function () {
    //Store language when changed
    Collective.Global.LanguageCallbacks.add(function () {
        Collective.Storage.Set("CurrentLanguage", Collective.Global.CurrentLanguage);
    });
    //Load current modules
    $("[data-type='module']").each(function () {
        var control = $(arguments[1]),
            moduleName = control.attr("data-module"),
            namespace = moduleName.split("."),
            resultModule = Collective;

        for (var i = 1; i < namespace.length; i++)
            resultModule = resultModule[namespace[i]];

        var moduleParameters = {};
        if (window.location.search)
        {
            var searchQuery = window.location.search.replace("?", "");
            searchElements = searchQuery.split("&");

            $.each(searchElements, function () {

                var itemElements = arguments[1].split("=");
                moduleParameters[itemElements[0]]=itemElements[1];
            });
        }
        resultModule.Load(control, moduleParameters);
    });
});