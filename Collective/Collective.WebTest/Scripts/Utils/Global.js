jQuery.namespace("Defero.Global");

$(document).ready(function () {
    $("div[data-type='module']").each(function () {
        var control = $(arguments[1]),
            moduleName = control.attr("data-module"),
            namespace = moduleName.split("."),
            resultModule = Defero;

        for (var i = 1; i < namespace.length; i++)
            resultModule = resultModule[namespace[i]];

        resultModule.Load(control);
    });

    $(".header .login").hover(function () {
        $(this).animate({ opacity: 0.25 }, 200);
    }, function () {
        $(this).animate({ opacity: 1 }, 200);
    });
});

Defero.Global.Init = function (view) {

    view.find("[data-control]").each(function (index, item) { 
        //TODO: implement custom controls
    });
};

Defero.Global.SetView = function (module, view) {

    module.Sidebar = $("[data-type='sidebar'][data-module]");
    module.View = view;
}

Defero.Global.Get = function (url, data, callback) {

    $.ajax({
        url: url,
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

Defero.Global.Load = function (url, data, viewModel) {
    
    if ($.isFunction(viewModel))
        Defero.Global.Get(url, data, function (result) {
            return viewModel(result);
        });

    return false;
};