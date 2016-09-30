using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Repositories.Mxp;
using NSubstitute;
using NUnit.Framework;

namespace Bloodhound.Data.Tests.Repositories
{
    [TestFixture]
    public class MxpCustomerRepositoryTests : RepositoryTestBase
    {
        const string SummaryProcedureName = "sharepoint.GetCustomerSummary";
        const string DetailProcedureName = "sharepoint.GetCustomerDetails";

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerName_ReturnsListOfCustomers()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(CustomerName,"");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerNameWhenNoResultsReturned_ReturnsEmptyListOfCustomers()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync(CustomerName, "");

            //Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerNumber_ReturnsListOfCustomers()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(SummaryProcedureName)));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync("", CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
        }

        [Test]
        async public Task GetTableEntitiesAsync_GivenACustomerNumberWhenNoResultsReturned_ReturnsEmptyListOfCustomers()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(SummaryProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var results = await repository.GetTableEntitiesAsync("", CustomerNumber);

            //Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        async public Task GetCustomerDetailAsync_GivenACustomerNumber_ReturnsACustomer()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(DetailProcedureName)));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var result = await repository.GetCustomerDetailAsync(CustomerNumber);

            //Assert
            Assert.That(result != null);
        }

        [Test]
        async public Task GetCustomerDetailAsync_GivenACustomerNumberThatDoesNotExist_ReturnsNull()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(DetailProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpCustomerRepository(sqlClient);

            //Act
            var result = await repository.GetCustomerDetailAsync(CustomerNumber);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
