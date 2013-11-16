//jQuery.namespace("Collective.Translations");

Collective.Translations = {
    SPA: {
        Galleries: "Explorar",
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
        Size: "Formato",
        Photography: "Fotografia",
        ViewArtistGallery: "Ver Galeria del Artista",
        Related: "Relacionados",
        Username: "Nombre de Usuario",
        Password: "Contraseña",
        Email: "Email",
        ConfirmPassword: "Confirmar contraseña",
        HeaderLogin: "LogIn y compra en linea",
        HeaderRegister: "No tienes una cuenta? Registrate!",
        LoginAndRegister: "Login & Registro",
        AdminAccess: "Acceso a administración",
        Name: "Nombre",
        Phone: "Telefono",
        Message: "Mensaje",
        Send: "Enviar",
        ViewLargerMap: "Ver en Grande",
        Presenting: "Presentando",
        IndexTitle: "Parte de la serie COLEC7IVA Master Photography por",
        StartingAt: "A partir de",
        OrderNow: "Ordena en linea"
    },
    ENG: {
        Galleries: "Browse",
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
        Size: "Format",
        Photography: "Photography",
        ViewArtistGallery: "View Artist´s Gallery",
        Related: "Related",
        Username: "Username",
        Password: "Password",
        Email: "Email",
        ConfirmPassword: "Confirm password",
        HeaderLogin: "Login & Shop Online",
        HeaderRegister: "Don´t have an Account? Register!",
        LoginAndRegister: "Login & Register",
        AdminAccess: "Admininistration Access",
        Name: "Name",
        Phone: "Phone",
        Message: "Message",
        Send: "Send",
        ViewLargerMap: "View Larger Map",
        Presenting: "Presenting",
        IndexTitle: "Part of the COLEC7IVA Master Photography Series by",
        StartingAt: "Starting at",
        OrderNow: "Order now online"
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

        $.each(view.find("[data-holder]"), function () {

            var control = $(this);
            var text = translations[control.data("holder")];

            var hasTransform = control.is("[data-transform]");
            if (hasTransform) {
                switch (control.data("transform")) {
                    case "AllCaps":
                        text = text.toUpperCase();
                        break;
                }
            }
            control.attr("placeholder", text);
        });
    }
};