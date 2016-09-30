using Autofac;
using Autofac.Integration.Mvc;
using BloodHound.Data;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BloodHound.Core;
using Settings = BloodHound.Core.Settings;

namespace BloodHound.AppWeb
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterModule<AppWebModule>();
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule(new DataModule(Settings.Database.ConnectionString));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}