﻿using AcmeRemote.DataService;
using DependencyInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace AcmeRemoteFlight
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
           var resolver = Container.DependencyResolver;
           var service = resolver.Resolve<IService>();
            if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\bin\"+ "flights.json"))
                service.SaveFlightsDefaults();
        }
    }
}
