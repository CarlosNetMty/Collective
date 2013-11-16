jQuery.namespace("Collective.Shared");

(function () {
    Collective.Shared.ImageUpload = {
        DataUrl: "/Home/Upload",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            var submit = self.View.find("input[type=submit]"),
                input = self.View.find("input[type=file]"),
                form = self.View.find("form");

            function post()
            {
                $.ajax({
                    data: form.serialize(),
                    url: self.DataUrl,
                    dataType: 'json',
                    type: "POST",
                    //async: false,
                    cache: false,
                    beforeSend: function () { Collective.Utils.Notify("Upload Started", "info"); },
                    complete: function () { Collective.Utils.Notify("Upload Finished", "info"); },
                    success: function () { Collective.Utils.Notify("Success on Upload"); }
                });
            }

            function init()
            {
                submit.bind("click", post);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);