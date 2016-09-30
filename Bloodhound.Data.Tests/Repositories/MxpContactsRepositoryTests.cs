using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.Data.Repositories.Mxp;
using NSubstitute;
using NUnit.Framework;

namespace Bloodhound.Data.Tests.Repositories
{
    [TestFixture]
    public class MxpContactsRepositoryTests : RepositoryTestBase
    {
        const string ProcedureName = "sharepoint.GetContactDetails";

        [Test]
        async public Task GetDetailEntitiesAsync_GivenACustomerNumber_ReturnsListOfContacts()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(ProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(ProcedureName)));
            var repository = new MxpContactRepository(sqlClient);

            //Act
            var results = await repository.GetDetailEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
        }

        [Test]
        public async Task GetDetailEntitiesAsync_GivenACustomerNumberThatReturnsNoContacts_ReturnsEmptyListOfContacts()
        {
            //Arrange
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(ProcedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpContactRepository(sqlClient);

            //Act
            var results = await repository.GetDetailEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results, Is.Empty);
        }
    }
}
