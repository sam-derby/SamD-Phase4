using Autofac;
using BloodHound.Core.Azure;
using BloodHound.Core.Configs;
using BloodHound.Core.Logging;

namespace BloodHound.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogTableConfig>().As<ITableConfig>().SingleInstance();
            builder.RegisterType<LogTableService>()
                .As<ILogTableService>()
                .InstancePerDependency()
                .OnActivated(e => e.Instance.Initialise());
            builder.RegisterType<LogWriter>().As<ILogWriter>().SingleInstance();
            base.Load(builder);
        }
    }
}
