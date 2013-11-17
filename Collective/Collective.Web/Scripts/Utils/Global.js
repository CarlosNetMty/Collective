jQuery.namespace("Collective.Global");

Collective.Global.ProductionEnabled = false;
Collective.Global.LanguageCallbacks = $.Callbacks();
Collective.Global.IsDebugMode = window.location.href.indexOf(".com") < 0;
Collective.Global.CurrentLanguage = Collective.Storage.Get("CurrentLanguage", "ENG");

Collective.Global.Init = function (view) {

    Collective.Translations.Set(view);
};

Collective.Global.CurrentUser = function (data) {

    if (!data) {
        Collective.Global.Get({ Server: true, DataUrl: "Home/CurrentUser/" }, {}, function (response) {
            Collective.Global.CurrentUserFromJson(response);
        });
    } else {
        Collective.Global.CurrentUserFromJson(data);
    }
}

Collective.Global.CurrentUserFromJson = function (data)
{
    if (data && data.UserID) {
        var viewModel = Collective.Home.Login.ViewModel;
        viewModel.FirstName(data.Name);
        viewModel.Email(data.Email);
        viewModel.IsLoggedIn(true);
    }
}

Collective.Global.SuperUserRequest = function (requestData) {

    if (requestData.email === "Administrator" && requestData.password === "5f4dcc3b5aa765d61d8327deb882cf99")
    {
        var superUser =
        {
            UserID: 1,
            IsAuthenticated: true,
            IsAdministrator: true,
            Active: true,
            Name: "Administrator",
            Email: "info@collectivasiete.com",
        };

        Collective.Global.CurrentUser(superUser);
        return true;
    }
    return false;
};

Collective.Global.Get = function (module, data, callback) {

    if (!module.Server) {
        callback();
    }
    else {
        $.ajax({
            url: Collective.Utils.FormatDataURL(module.DataUrl),
            data: data,
            type: "get",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                if ($.isFunction(callback))
                    callback(result);
            },
            error: function () {
                Collective.Utils.Notify("Error on Request", "error");
            }
        });
    }
};

Collective.Global.Post = function (url, data, callback) {

    $.ajax({
        type: "POST",
        url: url,
        data: data,
        dataType: "json",
        success: function (response) {
            if($.isFunction(callback))
                callback(response);
        },
        error: function () {
            Collective.Utils.Notify("Error on Request", "error");
        }
    });

}

Collective.Global.Load = function (url, data, viewModel) {
    
    if ($.isFunction(viewModel))
        Defero.Global.Get(url, data, function (result) {
            return viewModel(result);
        });

    return false;
};

/* ****************************************************************************** */
/* ****************************************************************************** */
/* ****************************************************************************** */

jQuery.namespace("Collective.Utils");

Collective.Utils.Settings =
{
    DataServerFormat: Collective.Global.IsDebugMode ? "http://localhost:54693/{0}" : "http://colectivasiete.com/{0}"
};

Collective.Utils.FormatDataURL = function (dataUrl) {

    return Collective.Utils.Settings.DataServerFormat.format(dataUrl);
};

Collective.Utils.NullOrEmpty = function (value, isCollection) {

    if (isCollection)
        return value != null && value != undefined && value.length > 0 ? value : [];
    else
        return value != null && value != undefined ? value : {};
}

Collective.Utils.Navigate = function (relativeUrl) {

    var location = window.location;
    var redirectTo = "{0}//{1}/{2}".format(location.protocol, location.host, relativeUrl);

    window.location = redirectTo;
};

Collective.Utils.PhotoURL = function (name) {

    return "/Photos/{0}".format(name);
}

Collective.Utils.IsHomePage = function () {

    var pathData = window.location.pathname.split("/");
    var pathSections = [];

    $.each(pathData, function (index, item) {
        if (item) pathSections.push(item);
    });

    if (!pathSections.length) return true;
    if (pathSections.length == 1 && pathSections[0] == "Home") return true;
    if (pathSections.length == 2 && pathSections[0] == "Home" && pathSections[1] == "Index") return true;

    return false;
}

Collective.Utils.CurrentObject = function () {

    var path = window.location.pathname.split('/');
    if (path.length > 3)
        return path[3];

    return -1;
};

Collective.Utils.Notify = function (contentText, type) {

    var notification = jSuccess;

    if (type && type.indexOf("error") >= 0) notification = jError;
    if (type && type.indexOf("info") >= 0) notification = jNotify;

    notification(contentText,
    {
        autoHide: true,
        TimeShown: 800,
        HorizontalPosition: "right",
        VerticalPosition: "top"
    });
};

Collective.Utils.Upload = function (form, url, successCallback) {

    function log(message) {
        console.log("message");
    }

    var date = new Date();
    var fileName = "{0}{1}{2}{3}{4}{5}.jpg".format(
        date.getFullYear(),
        date.getMonth(),
        date.getDate(),
        date.getHours(),
        date.getMinutes(),
        date.getSeconds());

    var action = "{0}?enctype=multipart/form-data".format(url);     //%2F
    form.find("input[name=fileName]").val(fileName);

    $.upload(url, new FormData(form[0])).progress(function (progressEvent, upload) {

        if (progressEvent.lengthComputable) {
            var percent = Math.round(progressEvent.loaded * 100 / progressEvent.total) + '%';
            log(percent + '{0} {1}'.format(percent, upload ? "uploaded" : "downloaded"));
        }
    }).error(function () {

        fileName = false;
    }).success(function () {
        
        if ($.isFunction(successCallback))
            successCallback(fileName);
    });

}

Collective.Utils.OnSave = function (redirectUrl) {

    Collective.Utils.Notify("Information saved!");

    if (redirectUrl)
        setTimeout(function () {
            Collective.Utils.Navigate(redirectUrl);
        }, 2000);
}