jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Conditions = {
        DataUrl: "Home/About",
        Server: false,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //initializarion callback
            function init() {
                var content = self.View.find("[name='Content']").val();
                self.View.find("div:first").html(content);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

