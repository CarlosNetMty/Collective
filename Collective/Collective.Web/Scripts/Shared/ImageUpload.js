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
                Collective.Utils.Upload(form, "/Home/Upload", function (fileName) {

                    if (fileName)
                        Collective.Admin.ProductsDetail.ViewModel.PhotoURL(fileName);
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