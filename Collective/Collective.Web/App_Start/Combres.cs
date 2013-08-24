[assembly: WebActivator.PreApplicationStartMethod(typeof(Collective.Web.App_Start.Combres), "PreStart")]
namespace Collective.Web.App_Start {
	using System.Web.Routing;
	using global::Combres;
	
    public static class Combres {
        public static void PreStart() {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}