﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebHospital
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{fullname}",
                defaults: new { fullname = RouteParameter.Optional }
            );
        }
    }
}
