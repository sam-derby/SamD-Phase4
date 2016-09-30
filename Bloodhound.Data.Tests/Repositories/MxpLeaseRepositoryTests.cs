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
    public class MxpLeaseRepositoryTests : RepositoryTestBase
    {
        const string SummaryProcedureName = "sharepoint.GetLeaseSummary";
        const string DetailProcedureName = "sharepoint.GetLeaseDetails";

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerNumber_ReturnsListOfLeases()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpLeaseRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received().ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
                Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == CustomerNumber));
        }

        [Test]
        public async Task GetTableEntitiesAsync_GivenACustomerNumberThatDoesntExist_ReturnsEmptyListOfLeases()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpLeaseRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results, Is.Empty);
            await sqlClient.Received().ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
               Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == CustomerNumber));
        }

        [Test]
        async public Task GetDetailEntitieAsync_GivenALeaseId_ReturnsLease()
        {
            //Arrange
            const int leaseId = 8;
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(DetailProcedureName)));
            var repository = new MxpLeaseRepository(sqlClient);

            //Act
            var result = await repository.GetDetailEntitieAsync(leaseId);

            //Assert
            Assert.That(result != null);
            await sqlClient.Received().ExecuteReaderSpAsync(Arg.Is(DetailProcedureName),
                Arg.Is<SqlParameter[]>(x => Convert.ToInt32(x[0].Value) == leaseId));
        }

        [Test]
        async public Task GetDetailEntitieAsync_GivenALeaseIdThatDoesNotExist_ReturnsNullLease()
        {
            //Arrange
            const int leaseId = 8;
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpLeaseRepository(sqlClient);

            //Act
            var result = await repository.GetDetailEntitieAsync(leaseId);

            //Assert
            Assert.That(result, Is.Null);
            await sqlClient.Received().ExecuteReaderSpAsync(Arg.Is(DetailProcedureName),
                Arg.Is<SqlParameter[]>(x => Convert.ToInt32(x[0].Value) == leaseId));
        }

        [Test]
        async public Task SearchTableEntitiesAsync_GivenAPartialLeaseRef_ReturnsListOfLeases()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpLeaseRepository(sqlClient);

            //Act
            var results = await repository.SearchTableEntitiesAsync("123");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received().ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName),
                Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == "%123%"));
        }
    }
}
