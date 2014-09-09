using balaban.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace balaban
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<bContext>(new bInitializer()); //db yi re-generate eder
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<bContext>()); //sadece model değişikliği varsa db yi re-generate eder
            //Database.SetInitializer<bContext>(null); //db ye dokunmadan sadece kullanır
            //Database.SetInitializer(new bInitializer());//krsln


 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
