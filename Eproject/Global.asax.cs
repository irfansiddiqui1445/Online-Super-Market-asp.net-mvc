using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Eproject
{
    
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            HttpContext.Current.Session["Email"] = "Guest";
            HttpContext.Current.Session["User_Name"] = "Guest";
            HttpContext.Current.Session["User_Type"] = "Guest";
            HttpContext.Current.Session["User_ID"] = path;
            
        }
    }
}