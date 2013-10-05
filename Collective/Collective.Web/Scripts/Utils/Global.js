jQuery.namespace("Collective.Global");

Collective.Global.CurrentLanguage = Collective.Storage.Get("CurrentLanguage", "ENG");
Collective.Global.LanguageCallbacks = $.Callbacks();

Collective.Global.Init = function (view) {

    Collective.Translations.Set(view);
};


Collective.Global.Loader =
{
    Show: function () {

        if (!this.Control)
            this.Control = $("[data-type='Loader']");

        if (!this.Active)
        {
            this.Control.show();
            this.Active = true;
        }
    },
    Hide: function () {

        this.Control.hide();
        this.Active = false;
    }
};

Collective.Global.CurrentUser = function (data)
{
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

Collective.Global.Get = function (module, data, callback) {

    Collective.Global.Loader.Show();

    if (!module.Server) {
        callback();
        Collective.Global.Loader.Hide();
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

                Collective.Global.Loader.Hide();
            }
        });
    }
};

Collective.Global.Post = function (url, data, callback)
{

    $.ajax({
        type: "POST",
        url: url,
        data: data,
        dataType: "json",
        success: function (response)
        {
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

$.noty.defaults = {
    layout: 'top',
    theme: 'defaultTheme',
    type: 'alert',
    text: '',
    dismissQueue: true, // If you want to use queue feature set this true
    template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
    animation: {
        open: { height: 'toggle' },
        close: { height: 'toggle' },
        easing: 'swing',
        speed: 500 // opening & closing animation speed
    },
    timeout: false, // delay for closing event. Set false for sticky notifications
    force: false, // adds notification to the beginning of queue when set to true
    modal: false,
    maxVisible: 5, // you can set max visible notification for dismissQueue true option
    closeWith: ['click'], // ['click', 'button', 'hover']
    callback: {
        onShow: function () { },
        afterShow: function () { },
        onClose: function () { },
        afterClose: function () { }
    },
    buttons: false // an array of buttons
};