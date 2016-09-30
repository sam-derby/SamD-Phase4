using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Interfaces;
using NSubstitute;

namespace Bloodhound.Data.Tests.Repositories
{
    public class RepositoryTestBase
    {
        protected const string CustomerNumber = "111222";
        protected const string CustomerName = "TestCustomer";

        protected static ISQLClient CreateSqlClient()
        {
            return Substitute.For<ISQLClient>();
        }
    }
}
