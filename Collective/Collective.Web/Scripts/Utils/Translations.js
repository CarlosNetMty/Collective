//jQuery.namespace("Collective.Translations");

Collective.Translations = {
    SPA: {
        Galleries: "Galerias",
        About: "Acerca",
        Contact: "Contacto",
        Language: "Lenguaje",
        Welcome: "Bienvenido",
        SecurePayment: "Pago Seguro",
        OrderHistory: "Hisorial de Pagos",
        TermsOfService: "Terminos de Servicio",
        AllRightsReserved: "Todos los derechos reservados"
    },
    ENG: {
        Galleries: "Galleries",
        About: "About",
        Contact: "Contact",
        Language: "Language",
        Welcome: "Welcome back",
        SecurePayment: "Secure Payment",
        OrderHistory: "Order History",
        TermsOfService: "Terms of Service",
        AllRightsReserved: "All rights reserved"
    },
    Get: function (key)
    {
        return this[Collective.Global.CurrentLanguage][key];
    },
    Set: function (view)
    {
        var lang = Collective.Global.CurrentLanguage;
        var translations = Collective.Translations[lang];
        
        $.each(view.find("[data-key]"), function () {

            var control = $(this);
            control.text(translations[control.data("key")]);
        });
    }
};