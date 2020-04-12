using LiteLibrary.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LiteLibrary
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();

            string connectionString = @"server=DESKTOP-6GHLID0\SQLEXPRESS;user id=sa;password=123;database=LiteLibrary"; // truyen vao de ket noi
            LiteLibrary.BusinessLayers.ShopManagementBLL.KhoiTao(connectionString);
         
        }
    }
}
