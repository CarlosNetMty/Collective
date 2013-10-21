jQuery.namespace("Collective.Global");

Collective.Global.ProductionEnabled = false;
Collective.Global.CurrentLanguage = Collective.Storage.Get("CurrentLanguage", "ENG");
Collective.Global.LanguageCallbacks = $.Callbacks();

Collective.Global.Init = function (view) {

    Collective.Translations.Set(view);
};

Collective.Global.Loader = {
    Show: function () {
        if (!this.Control) this.Control = $("[data-type='Loader']");

        if (!this.Active) {
            this.Control.show();
            this.Active = true;
        }
    },
    Hide: function () {
        this.Control.hide();
        this.Active = false;
    }
};

Collective.Global.CurrentUser = function (data) {

    if (!data) {
        Collective.Global.Get({ Server: true, DataUrl: "Home/CurrentUser/" }, {}, function (response) {
            Collective.Global.CurrentUserFromJson(response);
        });
    }
    else {
        Collective.Global.CurrentUserFromJson(data);
    }
}

Collective.Global.CurrentUserFromJson = function (data)
{
    if (data && data.UserID) {
        var viewModel = Collective.Home.Footer.ViewModel;
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
        success: function (response)
        {
            if($.isFunction(callback))
                callback(response);
        },
        error: function ()
        {
            debugger;
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