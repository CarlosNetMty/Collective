jQuery.namespace("Collective.Home");

(function () {
    Collective.Home.Gallery = {
        DataUrl: "/Home/Products",
        Server: true,
        ViewModel: {},
        View: {},
        Load: function (control) {
            //Initial set
            var self = this;
            self.View = control;

            //Language change
            Collective.Global.LanguageCallbacks.add(function () {
                Collective.Global.Init(self.View);
            });

            //initializarion callback
            function init(data) {
                self.ViewModel = new Collective.ViewModels.Gallery(data);
                self.View.find(".fancybox").fancybox({ maxWidth: 450, maxHeight: 500, padding: 50 });

                var $container = self.View.find("#container");
                $container.imagesLoaded(function () {
                    $container.isotope({
                        masonry: { columnWidth: 110, gutterWidth: 0 }
                    });
                });

                self.View.find('#filters a').click(function () {
                    var selector = $(this).attr('data-filter');
                    $container.isotope({ filter: selector });
                    return false;
                });

                
                self.View.find('div.selectBox').each(function () {
                    $(this).children('a.selected').html($(this).children('div.selectOptions').children('a.selectOption:first').html());
                    $(this).attr('value', $(this).children('div.selectOptions').children('a.selectOption:first').attr('value'));

                    $(this).children('span.selected,span.selectArrow').click(function () {
                        if ($(this).parent().children('div.selectOptions').css('display') == 'none') {
                            $(this).parent().children('div.selectOptions').css('display', 'block');
                        }
                        else {
                            $(this).parent().children('div.selectOptions').css('display', 'none');
                        }
                    });

                    $(this).find('a.selectOption').click(function () {
                        $(this).parent().css('display', 'none');
                        $(this).closest('div.selectBox').attr('value', $(this).attr('value'));
                        $(this).parent().siblings('a.selected').html($(this).html());
                    });
                });
                
                ko.applyBindings(self.ViewModel, control.context);
            }

            //Get server data (if needed)
            Collective.Global.Get(this, {}, init);
            //Custom Controls (include translations)
            Collective.Global.Init(this.View);
        }
    };
})(jQuery);

/*************************************/
/************* ViewModel *************/
/*************************************/

jQuery.namespace("Collective.ViewModels");

Collective.ViewModels.Gallery = function (model) {
    // ViewModel
    var self = this;
    //Header Items
    self.Items = ko.observableArray(Collective.Utils.NullOrEmpty(model.Items, true));
}