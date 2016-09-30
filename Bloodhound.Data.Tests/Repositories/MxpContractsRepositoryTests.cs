using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Repositories.Mxp;
using NSubstitute;
using NUnit.Framework;

namespace Bloodhound.Data.Tests.Repositories
{
    public class MxpContractsRepositoryTests : RepositoryTestBase
    {
        [Test]
        async public Task GetContractHeaderTableEntitiesAsync_GivenACustomerNumber_ReturnsListOfContractHeaders()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractHeaderSummary";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(procedureName)));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var results = await repository.GetContractHeaderTableEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
        }

        [Test]
        async public Task GetContractHeaderTableEntitiesAsync_GivenACustomerNumberThatDoesNotExist_ReturnsEmptyListOfContractHeaders()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractHeaderSummary";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var results = await repository.GetContractHeaderTableEntitiesAsync(CustomerNumber);

            //Assert
            Assert.That(results, Is.Empty);
        }

        [Test]
        async public Task SeacrhContractHeaderTableEntitiesAsync_GivenAPartialCustomerNumber_ReturnsListOfContractHeaders()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractHeaderSummary";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(procedureName)));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var results = await repository.SearchContractHeaderTableEntitiesAsync("123");

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
              .ExecuteReaderSpAsync(Arg.Is(procedureName),
              Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == "%123%"));
        }

        [Test]
        async public Task GetContractLinesTableEntitiesAsync_GivenAContractNumber_ReturnsListOfContractLines()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractLineSummary";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(procedureName)));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var results = await repository.GetContractLinesTableEntitiesAsync("contract_no",CustomerNumber);

            //Assert
            Assert.That(results != null);
            Assert.That(results.Any(), Is.EqualTo(true));
            await sqlClient.Received()
               .ExecuteReaderSpAsync(Arg.Is(procedureName),
               Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == "contract_no" && x[1].Value.ToString() == CustomerNumber));
        }

        [Test]
        async public Task GetContractLinesTableEntitiesAsync_GivenAContractNumberThatDoesNotExist_ReturnsEmptyListOfContractLines()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractLineSummary";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetEmptyTable()));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var results = await repository.GetContractLinesTableEntitiesAsync("contract_no",CustomerNumber);

            //Assert
            Assert.That(results, Is.Empty);
            await sqlClient.Received()
              .ExecuteReaderSpAsync(Arg.Is(procedureName),
              Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == "contract_no" && x[1].Value.ToString() == CustomerNumber));
        }

        [Test]
        async public Task GetContractLineDetailEntityAsync_GivenACustomerNumber_ReturnsALineDetail()
        {
            //Arrange
            const string procedureName = "sharepoint.GetContractLineDetails";
            var sqlClient = CreateSqlClient();
            sqlClient.ExecuteReaderSpAsync(Arg.Is(procedureName), Arg.Any<SqlParameter[]>())
                .Returns(m => Task.FromResult(TestHelpers.GetTable(procedureName)));
            var repository = new MxpContractsRepository(sqlClient);

            //Act
            var result = await repository.GetContractLineDetailEntityAsync(CustomerNumber,"contract_no","line_no");

            //Assert
            Assert.That(result, Is.Not.Null);
            await sqlClient.Received()
               .ExecuteReaderSpAsync(Arg.Is(procedureName),
               Arg.Is<SqlParameter[]>(x => x[0].Value.ToString() == CustomerNumber && x[1].Value.ToString() == "contract_no" && x[2].Value.ToString() == "line_no"));
        }

    }
}
