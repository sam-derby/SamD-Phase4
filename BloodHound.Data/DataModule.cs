using Autofac;
using BloodHound.Data.Interfaces;
using BloodHound.Data.Interfaces.Repositories;
using BloodHound.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Repositories.Crm;

using BloodHound.Data.Repositories.Mxp;

namespace BloodHound.Data
{
    public class DataModule : Module
    {
        readonly string _connectionString;

        public DataModule(string connString)
        {
            _connectionString = connString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new MockSQLClient()).As<ISQLClient>().InstancePerRequest();
            builder.Register(c => new SQLClient(_connectionString)).As<ISQLClient>().InstancePerRequest();
            builder.RegisterType<MxpCustomerRepository>().As<IMxpCustomerRepository>().InstancePerRequest();
            builder.RegisterType<MxpContactRepository>().As<IMxpContactRepository>().InstancePerRequest();
            builder.RegisterType<CrmAccountRepository>().As<ICrmAccountRepository>().InstancePerRequest();
            builder.RegisterType<CrmContactRepository>().As<ICrmContactRepository>().InstancePerRequest();
            builder.RegisterType<MxpDeviceRepository>().As<IMxpDeviceRepository>().InstancePerRequest();
            builder.RegisterType<CrmDeviceRepository>().As<ICrmDeviceRepository>().InstancePerRequest();
            builder.RegisterType<MxpContractsRepository>().As<IMxpContractsRepository>().InstancePerRequest();
            builder.RegisterType<MxpLeaseRepository>().As<IMxpLeaseRepository>().InstancePerRequest();
            builder.RegisterType<CrmCaseRepository>().As<ICrmCaseRepository>().InstancePerRequest();
            builder.RegisterType<CrmActivityRepository>().As<ICrmActivityRepository>().InstancePerRequest();
            builder.RegisterType<MxpServiceCallRepository>().As<IMxpServiceCallRepository>().InstancePerRequest();
            builder.RegisterType<CrmOpportunityRepository>().As<ICrmOpportunityRepository>().InstancePerRequest();
            base.Load(builder);

        }
    }
}
