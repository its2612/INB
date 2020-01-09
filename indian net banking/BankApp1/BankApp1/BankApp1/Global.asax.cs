﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BankApp1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpConfiguration config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        //protected void Application_BeginRequest()
        //{

        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
        //        // HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST,PUT, DELETE");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Accepts, Content-Type, Origin, X-My-Header");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
        //        HttpContext.Current.Response.End();
        //    }

        //}
    }
}
