//jQuery LIKE
String.prototype.format = String.prototype.format = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};

Number.prototype.padLeft = function (n, str) {
    if (!n) return;
    return (this < 0 ? '-' : '') +
            Array(n - String(Math.abs(this)).length + 1)
             .join(str || '0') +
           (Math.abs(this));
};

/* 
decimal_sep: character used as deciaml separtor, it defaults to '.' when omitted
thousands_sep: char used as thousands separator, it defaults to ',' when omitted
*/
Number.prototype.toMoney = function (decimals, decimal_sep, thousands_sep) {
    var n = this,
   c = isNaN(decimals) ? 2 : Math.abs(decimals), //if decimal is zero we must take it, it means user does not want to show any decimal
   d = decimal_sep || '.', //if no decimal separator is passed we use the dot as default decimal separator (we MUST use a decimal separator)

    /*
    according to [http://stackoverflow.com/questions/411352/how-best-to-determine-if-an-argument-is-not-sent-to-the-javascript-function]
    the fastest way to check for not defined parameter is to use typeof value === 'undefined' 
    rather than doing value === undefined.
    */
   t = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep, //if you don't want to use a thousands separator you can pass empty string as thousands_sep value

   sign = (n < 0) ? '-' : '',

    //extracting the absolute value of the integer part of the number and converting to string
   i = parseInt(n = Math.abs(n).toFixed(c)) + '',

   j = ((j = i.length) > 3) ? j % 3 : 0;
    return sign + (j ? i.substr(0, j) + t : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : '');
}

$(document).ready(function () {
    //Store language when changed
    Collective.Global.LanguageCallbacks.add(function () {
        Collective.Storage.Set("CurrentLanguage", Collective.Global.CurrentLanguage);
    });
    //Load current modules
    $("[data-type='module']").each(function () {
        var control = $(arguments[1]),
            moduleName = control.attr("data-module"),
            namespace = moduleName.split("."),
            resultModule = Collective;

        for (var i = 1; i < namespace.length; i++)
            resultModule = resultModule[namespace[i]];

        var moduleParameters = {};
        if (window.location.search)
        {
            var searchQuery = window.location.search.replace("?", "");
            searchElements = searchQuery.split("&");

            $.each(searchElements, function () {

                var itemElements = arguments[1].split("=");
                moduleParameters[itemElements[0]]=itemElements[1];
            });
        }
        resultModule.Load(control, moduleParameters);
    });
});