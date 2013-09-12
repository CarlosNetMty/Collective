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
        AllRightsReserved: "Todos los derechos reservados",
        Login: "Login",
        Register: "Registrar",
        FilterBy: "Filtar Por",
        ExcludingPrice: "(excluyendo impuestos y envio)",
        AddToCart: "Agregar a carrito de compra",
        Framing: "Enmarcado",
        Size: "Tamaño",
        Photography: "Fotografia",
        ViewArtistGallery: "Ver Galeria del Artista",
        Related: "Relacionados"
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
        AllRightsReserved: "All rights reserved",
        Login: "Login",
        Register: "Register",
        FilterBy: "Filter By",
        ExcludingPrice: "(excluding TAX & Shipping)",
        AddToCart: "Add to Shopping Cart",
        Framing: "Framing",
        Size: "Size",
        Photography: "Photography",
        ViewArtistGallery: "View Artist´s Gallery",
        Related: "Related"
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
            var text = translations[control.data("key")];

            var hasTransform = control.is("[data-transform]");
            if (hasTransform)
            {
                switch (control.data("transform"))
                {
                    case "AllCaps":
                        text = text.toUpperCase();
                        break;
                }
            }
            control.text(text);
        });
    }
};