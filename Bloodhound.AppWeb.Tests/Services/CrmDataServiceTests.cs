using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Services.Data;
using BloodHound.Core.Logging;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Enums;
using BloodHound.Data.Interfaces.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace Bloodhound.AppWeb.Tests.Services
{
    public class CrmDataServiceTests
    {
        const string AccountName = "account-name";
        const string CustomerNumber = "123456";
        readonly string _accountNumber = Guid.NewGuid().ToString();

        [Test]
        async public Task SearchByCustomerNameAsync_GivenACustomerName_ReturnsListOfCustomers()
        {
            //Arrange
            var accounts = new[]
            {
                new CrmAccountTableEntity {AccountName = AccountName}
            };
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(Arg.Is(AccountName))
                .Returns(accounts);
            var crmDataService = CreateCrmDataService(crmAccountRepository);

            //Act
            var response = await crmDataService.SearchByCustomerNameAsync(AccountName);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<CrmAccountTableEntity>);
        }

        [Test]
        async public Task SearchByCustomerNameAsync_GivenACustomerNameThatReturnsNoResults_ReturnsEmplyListOfCustomers()
        {
            //Arrange
            var accounts = new List<CrmAccountTableEntity>();
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(Arg.Is(AccountName))
                .Returns(accounts);
            var crmDataService = CreateCrmDataService(crmAccountRepository);

            //Act
            var response = await crmDataService.SearchByCustomerNameAsync(AccountName);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM accounts found for {0}", AccountName)));
            Assert.That(response.Data is IEnumerable<CrmAccountTableEntity>);
        }

        [Test]
        async public Task GetAccountAsync_GivenAnAccountNumber_ReturnsAccountWithSharepointUrl()
        {
            //Arrange
            var account = new CrmAccountDetailEntity {CrmSharepointId = "test-id"};
           
            var crmAccountRepository = CreateCrmAccountRepository();
            var sharepointSearchService = CreateSharepointSearchService();
            sharepointSearchService
                .GetCrmSiteUrl(Arg.Any<string>())
                .Returns("https://crm-site");
            crmAccountRepository
                .GetCrmAccountDetailAsync(Arg.Is(_accountNumber))
                .Returns(account);
            var crmDataService = CreateCrmDataService(crmAccountRepository, sharepointSearchService: sharepointSearchService);

            //Act
            var response = await crmDataService.GetAccountAsync(_accountNumber);

            //Assert
            Assert.That(account.CrmSharepointUrl, Is.EqualTo("https://crm-site"));
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmAccountDetailEntity);
        }

        [Test]
        async public Task GetAccountAsync_GivenAnAccountNumber_ReturnsAccountWithoutSharepointUrl()
        {
            //Arrange
            var account = new CrmAccountDetailEntity { CrmSharepointId = "test-id" };

            var crmAccountRepository = CreateCrmAccountRepository();
            var sharepointSearchService = CreateSharepointSearchService();
            sharepointSearchService
                .GetCrmSiteUrl(Arg.Any<string>())
                .Returns("");
            crmAccountRepository
                .GetCrmAccountDetailAsync(Arg.Is(_accountNumber))
                .Returns(account);
            var crmDataService = CreateCrmDataService(crmAccountRepository, sharepointSearchService: sharepointSearchService);

            //Act
            var response = await crmDataService.GetAccountAsync(_accountNumber);

            //Assert
            Assert.That(account.CrmSharepointUrl, Is.EqualTo(string.Empty));
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmAccountDetailEntity);
        }

        [Test]
        async public Task GetAccountAsync_GivenAnAccountNumberWhereAccountDoesNotExist_ReturnsNull404()
        {
            //Arrange
            var crmAccountRepository = CreateCrmAccountRepository();
            
            crmAccountRepository
                .GetCrmAccountDetailAsync(Arg.Is(_accountNumber))
                .Returns((CrmAccountDetailEntity)null);
            var crmDataService = CreateCrmDataService(crmAccountRepository);

            //Act
            var response = await crmDataService.GetAccountAsync(_accountNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM account found for {0}", _accountNumber)));
            Assert.That(response.Data,Is.Null);
        }

        [Test]
        async public Task GetMxpCrmRecordsAsync_GivenACustomerNumber_ReturnsListOfAssociatedCrmAccounts()
        {
            //Arrange
            var accounts = new[]
            {
                new CrmAccountTableEntity {AccountName = AccountName}
            };
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(mxpCustomerNumber: Arg.Is(CustomerNumber))
                .Returns(accounts);
            var crmDataService = CreateCrmDataService(crmAccountRepository);

            //Act
            var response = await crmDataService.GetMxpCrmRecordsAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<CrmAccountTableEntity>);
        }

        [Test]
        async public Task GetMxpCrmRecordsAsync_GivenACustomerNumberWhereNoAssociatedCrmAccounts_ReturnsEmptyListOfAssociatedCrmAccounts()
        {
            //Arrange
            var accounts = new List<CrmAccountTableEntity>();
            
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(mxpCustomerNumber: Arg.Is(CustomerNumber))
                .Returns(accounts);
            var crmDataService = CreateCrmDataService(crmAccountRepository);

            //Act
            var response = await crmDataService.GetMxpCrmRecordsAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM accounts found for {0}", CustomerNumber)));
            Assert.That(response.Data is IEnumerable<CrmAccountTableEntity>);
        }

        [Test]
        async public Task GetCrmContactsAsync_GivenAnAccountNumber_ReturnsListOfContacts()
        {
            //Arrange
            var contacts = new[]
            {
                new CrmContactTableEntity()
            };
            var crmContactRepository = CreateCrmContactRepository();
            crmContactRepository
                .GetTableEntitiesAsync(Arg.Is(_accountNumber))
                .Returns(contacts);
            var crmDataService = CreateCrmDataService(crmContactRepository:crmContactRepository);

            //Act
            var response = await crmDataService.GetCrmContactsAsync(_accountNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<CrmContactTableEntity>);
        }

        [Test]
        async public Task GetCrmContactsAsync_GivenAnAccountNumberWhereContactsDoNotExists_ReturnsEmptyListOfContacts()
        {
            //Arrange
            var contacts = new List<CrmContactTableEntity>();
            var crmContactRepository = CreateCrmContactRepository();
            crmContactRepository
                .GetTableEntitiesAsync(Arg.Is(_accountNumber))
                .Returns(contacts);
            var crmDataService = CreateCrmDataService(crmContactRepository: crmContactRepository);

            //Act
            var response = await crmDataService.GetCrmContactsAsync(_accountNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM contacts found for this account")));
            Assert.That(response.Data is IEnumerable<CrmContactTableEntity>);
        }

        [Test]
        async public Task GetCrmDevicesByMxpCustomerNumberAsync_GivenACustomerNumber_ReturnsListOfCrmdevices()
        {
            //Arrange
            var devices = new[]
            {
                new CrmDeviceTableEntity {ParentAccountId = _accountNumber},
                new CrmDeviceTableEntity {ParentAccountId = _accountNumber}
            };
            var accounts = new[]
            {
                new CrmAccountTableEntity {MxpCustomerNumber = CustomerNumber, AccountNumber = _accountNumber},
                new CrmAccountTableEntity {MxpCustomerNumber = CustomerNumber, AccountNumber = Guid.NewGuid().ToString()}
            };
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(mxpCustomerNumber: Arg.Is(CustomerNumber))
                .Returns(accounts);
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetTableEntitiesAsync(Arg.Any<Guid>())
                .Returns(devices);
            var crmDataService = CreateCrmDataService(crmAccountRepository, crmDeviceRepository:crmDeviceRepository);

            //Act
            var response = await crmDataService.GetCrmDevicesByMxpCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<CrmDeviceTableEntity>);
            await crmDeviceRepository
                .Received(2)
                .GetTableEntitiesAsync(Arg.Any<Guid>());
        }

        [Test]
        async public Task GetCrmDevicesByMxpCustomerNumberAsync_GivenACustomerNumberThatDoesNotexist_DoesNotGetCrmDevices()
        {
            //Arrange
            var accounts = new List<CrmAccountTableEntity>();
            var crmAccountRepository = CreateCrmAccountRepository();
            crmAccountRepository
                .GetTableEntitiesAsync(mxpCustomerNumber: Arg.Is(CustomerNumber))
                .Returns(accounts);
            var crmDeviceRepository = CreateCrmDeviceRepository();
            var crmDataService = CreateCrmDataService(crmAccountRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetCrmDevicesByMxpCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            await crmDeviceRepository
                .DidNotReceive()
                .GetTableEntitiesAsync(Arg.Any<Guid>());
        }

        [Test]
        async public Task GetDevicesByAccountNumberAsync_GivenAnAccountNumber_ReturnsListOfDevices()
        {
            //Arrange
            var devices = new[]
            {
                new CrmDeviceTableEntity()
            };
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetTableEntitiesAsync(Arg.Is(new Guid(_accountNumber)))
                .Returns(devices);
            var crmDataService = CreateCrmDataService(crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDevicesByAccountNumberAsync(_accountNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<CrmDeviceTableEntity>);
        }

        [Test]
        async public Task GetDeviceByDeviceIdAsync_GivenADeviceId_ReturnsADevice()
        {
            //Arrange
            var deviceId = Guid.NewGuid().ToString();
            var device = new CrmDeviceDetailEntity();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(new Guid(deviceId)))
                .Returns(device);
            var crmDataService = CreateCrmDataService(crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceByDeviceIdAsync(deviceId);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmDeviceDetailEntity);
        }

        [Test]
        async public Task GetDeviceByDeviceIdAsync_GivenADeviceIdThatDoesNotExists_ReturnsNull404()
        {
            //Arrange
            var deviceId = Guid.NewGuid().ToString();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(new Guid(deviceId)))
                .Returns((CrmDeviceDetailEntity)null);
            var crmDataService = CreateCrmDataService(crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceByDeviceIdAsync(deviceId);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM device found for device Id {0}", deviceId)));
            Assert.That(response.Data, Is.Null);
        }

        [Test]
        async public Task GetDeviceBySysRefAsync_GivenASystemrefd_ReturnsADevice()
        {
            //Arrange
            const string sysRef = "sys-ref";
            var device = new CrmDeviceDetailEntity();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
                .Returns(device);
            var crmDataService = CreateCrmDataService(crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmDeviceDetailEntity);
        }

        [Test]
        async public Task GetDeviceBySysRefAsync_GivenASystemRefThatDoesNotExists_ReturnsNull404()
        {
            //Arrange
            const string systemRef = "sys-ref";
            var crmDeviceRepository = CreateCrmDeviceRepository();
            crmDeviceRepository
                .GetDeviceDetailBySysRefAsync(Arg.Is(systemRef))
                .Returns((CrmDeviceDetailEntity)null);
            var crmDataService = CreateCrmDataService(crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceBySysRefAsync(systemRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No CRM device found for system reference number {0}", systemRef)));
            Assert.That(response.Data, Is.Null);
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndMxpDeviceExists_ReturnsADeviceSetsStatusToExistsCrmAndMxp()
        {
            //Arrange
            var device = new MxpDeviceDetailEntity();
            var crmDevice = new CrmDeviceDetailEntity();
            const string sysRef = "sys-ref";

            var mxpDeviceRepository = CreateMxpDeviceRepository();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns(device);
            crmDeviceRepository
               .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
               .Returns(crmDevice);
            var crmDataService = CreateCrmDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmDeviceDetailEntity);
            Assert.That(crmDevice.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.ExistsCrmAndMxp));
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndMxpDeviceDoesNotExist_ReturnsADeviceSetsStatusToDoesntExistInMxp()
        {
            //Arrange
            var crmDevice = new CrmDeviceDetailEntity();
            const string sysRef = "sys-ref";

            var mxpDeviceRepository = CreateMxpDeviceRepository();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns((MxpDeviceDetailEntity)null);
            crmDeviceRepository
               .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
               .Returns(crmDevice);
            var crmDataService = CreateCrmDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmDeviceDetailEntity);
            Assert.That(crmDevice.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.DoesntExistInMxp));
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndMxpDeviceExistsButWithADifferentCustomerNumber_ReturnsADeviceSetsStatusToExistsInMxpNotInCrm()
        {
            //Arrange
            var device = new MxpDeviceDetailEntity { MxpCustomerNumber = CustomerNumber };
            var crmDevice = new CrmDeviceDetailEntity { CustomerNumber = "333333" };
            const string sysRef = "sys-ref";

            var mxpDeviceRepository = CreateMxpDeviceRepository();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns(device);
            crmDeviceRepository
               .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
               .Returns(crmDevice);
            var crmDataService = CreateCrmDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await crmDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is CrmDeviceDetailEntity);
            Assert.That(crmDevice.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.ExistsInMxpNotInCrm));
        }

        static ICrmDataService CreateCrmDataService(ICrmAccountRepository crmAccountRepository = null,
         ICrmContactRepository crmContactRepository = null, ICrmDeviceRepository crmDeviceRepository = null,
         ISharepointSearchService sharepointSearchService = null, ILogWriter logWriter = null, IMxpDeviceRepository mxpDeviceRepository = null)
        {
            return new CrmDataService(crmAccountRepository ?? CreateCrmAccountRepository(),
                crmContactRepository ?? CreateCrmContactRepository(), crmDeviceRepository ?? CreateCrmDeviceRepository(),
                sharepointSearchService ?? CreateSharepointSearchService(),
                logWriter ?? CreateLogWriter(), mxpDeviceRepository ?? CreateMxpDeviceRepository());
        }

        static ICrmAccountRepository CreateCrmAccountRepository()
        {
            return Substitute.For<ICrmAccountRepository>();
        }

        static ICrmContactRepository CreateCrmContactRepository()
        {
            return Substitute.For<ICrmContactRepository>();
        }

        static ICrmDeviceRepository CreateCrmDeviceRepository()
        {
            return Substitute.For<ICrmDeviceRepository>();
        }

        static ISharepointSearchService CreateSharepointSearchService()
        {
            return Substitute.For<ISharepointSearchService>();
        }

        static IMxpDeviceRepository CreateMxpDeviceRepository()
        {
            return Substitute.For<IMxpDeviceRepository>();
        }

        static ILogWriter CreateLogWriter()
        {
            return Substitute.For<ILogWriter>();
        }
    }
}
