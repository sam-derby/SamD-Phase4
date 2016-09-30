using Autofac;
using BloodHound.AppWeb.Interfaces.Providers;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Providers;
using BloodHound.AppWeb.Services;
using BloodHound.AppWeb.Services.Data;

namespace BloodHound.AppWeb
{
    public class AppWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorisationService>().As<IAuthorisationService>().InstancePerRequest();
            builder.RegisterType<SharepointSearchService>().As<ISharepointSearchService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<MxpDataService>().As<IMxpDataService>().InstancePerRequest();
            builder.RegisterType<CrmDataService>().As<ICrmDataService>().InstancePerRequest();
            builder.RegisterType<CrmOpportunityDataService>().As<ICrmOpportunityDataService>().InstancePerRequest();
            builder.RegisterType<CrmCaseDataService>().As<ICrmCaseDataService>().InstancePerRequest();
            builder.RegisterType<DeviceSearchDataService>().As<IDeviceSearchDataService>().InstancePerRequest();
            builder.RegisterType<SharepointClientContextProvider>().As<ISharepointClientContextProvider>().InstancePerRequest();
            builder.RegisterType<SharepointListService>().As<ISharepointListService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
