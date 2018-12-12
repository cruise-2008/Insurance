using System.Web.Http;

namespace Insurance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultActionApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
