using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using WebProject.Hosts.Web.App_Start;

namespace WebProject.Hosts.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, string.Empty);

            config.Services.Replace(typeof(IHttpControllerTypeResolver),
                new HttpServiceTypeResolver());

            config.MapHttpAttributeRoutes();
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }

        #region codigo viejo
        //public static void Register(HttpConfiguration config)
        //{
        //    // Configuración y servicios de API web

        //    // Rutas de API web
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
        #endregion
    }
}
