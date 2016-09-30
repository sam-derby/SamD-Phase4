using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Repositories.Mxp;
using NSubstitute;
using NUnit.Framework;

namespace Bloodhound.Data.Tests.Repositories
{
    [TestFixture]
    public class MxpDeviceRepositoryTests : RepositoryTestBase
    {
        const string SummaryProcedureName = "sharepoint.GetDeviceSummary";
        const string DetailProcedureName = "sharepoint.GetDeviceDetails";

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerNumber_ReturnsListOfDevices()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(custNumber:CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
             .ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
             Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == string.Format("%{0}%", CustomerNumber) 
             && x[1].Value == null && x[2].Value == null && x[3].Value == null && x[4].Value == null));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenASystemRef_ReturnsListOfDevices()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(sysRef: "sysRef");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
            .ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
            Arg.Is<SqlParameter[]>(x => x[1].Value.ToString() == string.Format("%{0}%", "sysRef")
            && x[0].Value == null && x[2].Value == null && x[3].Value == null && x[4].Value == null));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenASerialNumber_ReturnsListOfDevices()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(serialNumber: "serialNumber");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
            .ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
            Arg.Is<SqlParameter[]>(x => x[2].Value.ToString() == string.Format("%{0}%", "serialNumber")
            && x[0].Value == null && x[1].Value == null && x[3].Value == null && x[4].Value == null));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenAnAltRef_ReturnsListOfDevices()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(altRef: "altRef");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
           .ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
               Arg.Is<SqlParameter[]>(x => x[3].Value.ToString() == string.Format("%{0}%", "altRef")
               && x[0].Value == null && x[1].Value == null && x[2].Value == null && x[4].Value == null));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenALeaseId_ReturnsListOfDevices()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(leaseId: 101);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
           .ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
           Arg.Is<SqlParameter[]>(x => Convert.ToInt32(x[4].Value) ==  101
           && x[0].Value == null && x[1].Value == null && x[2].Value == null && x[3].Value == null));
        }

        [Test]
        async public Task GetDeviceDetailAsync_GivenASystemRef_ReturnsDevice()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(DetailProcedureName)));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var result = await repository.GetDeviceDetailAsync("sys-ref");

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        async public Task GetDeviceDetailAsync_GivenAnInvalidSystemRef_ReturnsNoDevice()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpDeviceRepository(sqlClient);

            //Act
            var result = await repository.GetDeviceDetailAsync("sys-ref");

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
