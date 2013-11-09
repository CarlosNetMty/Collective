using System.Web;
using System.Web.Optimization;

namespace Collective.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // ****************  Styles  ****************
            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/content/normalize.css",
                        "~/content/main.css",
                        "~/content/jnotify.css"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/content/foundation.css",
                        "~/content/jquery-te.css",
                        "~/content/jnotify.css"));

            // ****************  Scripts  ****************
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/scripts/framework/modernizr-2.6.2.js", 
                        "~/scripts/framework/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/framework")
                .Include("~/scripts/framework/jquery.validate.js",
                        "~/scripts/framework/jquery.validate.unobtrusive.js",
                        "~/scripts/framework/knockout-2.3.0.js",
                        "~/scripts/framework/jquery.linq.js",
                        "~/scripts/framework/jquery.slabtext.js",
                        "~/scripts/framework/json2.js",
                        "~/scripts/framework/jstorage.js",
                        "~/scripts/framework/jquery.timers.js",
                        "~/scripts/framework/plugins.js",
                        "~/scripts/framework/jquery.fancybox.pack.js",
                        "~/scripts/framework/jquery.isotope.js",
                        "~/scripts/framework/foundation.js",
                        "~/scripts/framework/jquery-te-1.4.0.min.js",
                        "~/scripts/framework/jNotify.jquery.js",
                        "~/scripts/framework/jquery.noty.js",
                        "~/scripts/framework/jquery.md5.js",
                        "~/scripts/namespace.js"));

            bundles.Add(new ScriptBundle("~/bundles/application").Include(
                        // ****************  Common  ****************
                        "~/scripts/utils/Storage.js",
                        "~/scripts/utils/Global.js",
                        "~/scripts/utils/Translations.js",
                        "~/scripts/utils/Utileries.js",
                        // ****************  Home  ****************
                        "~/scripts/sales/Index.js",
                        "~/scripts/home/Index.js",
                        "~/scripts/home/Header.js",
                        "~/scripts/home/Footer.js",
                        "~/scripts/home/Gallery.js",
                        "~/scripts/home/Detail.js",
                        "~/scripts/home/Login.js",
                        "~/scripts/home/About.js",
                        "~/scripts/home/Contact.js",
                        "~/scripts/home/Conditions.js",
                        // ****************  Admin  ****************
                        "~/scripts/admin/Content.js",
                        "~/scripts/admin/Header.js",
                        "~/scripts/admin/Sidebar.js",
                        "~/scripts/admin/Index.js",
                        "~/scripts/admin/Artists.js",
                        "~/scripts/admin/ArtistsDetail.js",
                        "~/scripts/admin/Users.js",
                        "~/scripts/admin/UsersDetail.js",
                        "~/scripts/admin/Products.js",
                        "~/scripts/admin/ProductsDetail.js",
                        "~/scripts/admin/Cover.js",
                        "~/scripts/admin/Setting.js",
                        // ****************  Admin  ****************                        
                        "~/scripts/viewmodels/Collection.js",
                        "~/scripts/viewmodels/Sale.js",
                        "~/scripts/viewmodels/Footer.js",
                        "~/scripts/viewmodels/User.js",
                        "~/scripts/viewmodels/Artist.js"));
        }
    }
}