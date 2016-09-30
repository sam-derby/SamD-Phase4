using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.AppWeb.Interfaces.Services;
using BloodHound.AppWeb.Services.Data;
using BloodHound.Core.Logging;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;
using BloodHound.Data.Enums;
using BloodHound.Data.Interfaces.Repositories;
using BloodHound.Data.Repositories.Crm;
using BloodHound.Data.Repositories.Mxp;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal.Builders;

namespace Bloodhound.AppWeb.Tests.Services
{
    [TestFixture]
    public class MxpDataServiceTests
    {
        const string CustomerName = "test-customer";
        const string CustomerNumber = "123456";

        [Test]
        async public Task SearchByCustomerNameAsync_GivenACustomerName_ReturnsListOfCustomers()
        {
            //Arrange
            var customers = new[]
            {
                new MxpCustomerTableEntity {CustomerName = CustomerName}
            };
            var mxpCustomerRepository = CreateMxpCustomerRepository();
            mxpCustomerRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerName),"")
                .Returns(customers);
            var mxpDataService = CreateMxpDataService(mxpCustomerRepository);

            //Act
            var response = await mxpDataService.SearchByCustomerNameAsync(CustomerName);

            //Assert
            Assert.That(response.ResponseCode,Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpCustomerTableEntity>);
        }

        [Test]
        async public Task SearchByCustomerNameAsync_GivenACustomerNameAndNoResultsReturned_ReturnsEmptyListOfCustomersAnd204()
        {
            //Arrange
            var customers = new List<MxpCustomerTableEntity>();
            var mxpCustomerRepository = CreateMxpCustomerRepository();
            mxpCustomerRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerName), "")
                .Returns(customers);
            var mxpDataService = CreateMxpDataService(mxpCustomerRepository);

            //Act
            var response = await mxpDataService.SearchByCustomerNameAsync(CustomerName);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No MXP customers found for {0}",CustomerName)));
            Assert.That(response.Data is IEnumerable<MxpCustomerTableEntity>);
        }

        [Test]
        async public Task SearchByCustomerNumberAsync_GivenACustomerNumber_ReturnsListOfCustomers()
        {
            //Arrange
            var customers = new[]
            {
                new MxpCustomerTableEntity {CustomerNumber = CustomerNumber}
            };
            var mxpCustomerRepository = CreateMxpCustomerRepository();
            mxpCustomerRepository
                .GetTableEntitiesAsync("", Arg.Is(CustomerNumber))
                .Returns(customers);
            var mxpDataService = CreateMxpDataService(mxpCustomerRepository);

            //Act
            var response = await mxpDataService.SearchByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpCustomerTableEntity>);
        }

        [Test]
        async public Task GetCustomerAsync_GivenACustomerNumber_ReturnsACustomer()
        {
            //Arrange
            var customer = new MxpCustomerDetailEntity();
            var mxpCustomerRepository = CreateMxpCustomerRepository();
            mxpCustomerRepository
                .GetCustomerDetailAsync(Arg.Is(CustomerNumber))
                .Returns(customer);
            var mxpDataService = CreateMxpDataService(mxpCustomerRepository);

            //Act
            var response = await mxpDataService.GetCustomerAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpCustomerDetailEntity);
        }

        [Test]
        async public Task GetCustomerAsync_GivenACustomerNumberAndNoResultReturned_ReturnsNullDataAnd404()
        {
            //Arrange
            var mxpCustomerRepository = CreateMxpCustomerRepository();
            mxpCustomerRepository
                .GetCustomerDetailAsync(Arg.Is(CustomerNumber))
                .Returns((MxpCustomerDetailEntity)null);
            var mxpDataService = CreateMxpDataService(mxpCustomerRepository);

            //Act
            var response = await mxpDataService.GetCustomerAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No MXP Customer found for {0}", CustomerNumber)));
            Assert.That(response.Data, Is.Null);
        }

        [Test]
        async public Task GetContactsSummaryAsync_GivenACustomerNumber_ReturnsListOfContacts()
        {
            //Arrange
            var contacts = new[]
            {
                new MxpCustomerContactDetailEntity {CustomerNumber = CustomerNumber}
            };
            var mxpContactsRepository = CreateMxpContactRepository();
            mxpContactsRepository
                .GetDetailEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(contacts);
            var mxpDataService = CreateMxpDataService(mxpContactRepository:mxpContactsRepository);

            //Act
            var response = await mxpDataService.GetContactsSummaryAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpCustomerContactDetailEntity>);
        }

        [Test]
        async public Task GetContactsSummaryAsync_GivenACustomerNumberAndNoContactsReturned_ReturnsEmptyListOfContacts204()
        {
            //Arrange
            var contacts = new List<MxpCustomerContactDetailEntity>();
            var mxpContactsRepository = CreateMxpContactRepository();
            mxpContactsRepository
                .GetDetailEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(contacts);
            var mxpDataService = CreateMxpDataService(mxpContactRepository: mxpContactsRepository);

            //Act
            var response = await mxpDataService.GetContactsSummaryAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No MXP contacts found for Customer Number {0}",CustomerNumber)));
            Assert.That(response.Data is IEnumerable<MxpCustomerContactDetailEntity>);
        }

        [Test]
        async public Task GetDevicesByCustomerNumberAsync_GivenACustomerNumber_ReturnsListOfDevices()
        {
            //Arrange
            var devices = new[]
            {
                new MxpDeviceTableEntity {MxpCustomerNumber = CustomerName}
            };
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            mxpDeviceRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(devices);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository);

            //Act
            var response = await mxpDataService.GetDevicesByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpDeviceTableEntity>);
        }

        [Test]
        async public Task GetDevicesByCustomerNumberAsync_GivenACustomerNumberWhereNoDevicesExist_ReturnsEmptyListOfDevices204()
        {
            //Arrange
            var devices = new List<MxpDeviceTableEntity>();
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            mxpDeviceRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(devices);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository);

            //Act
            var response = await mxpDataService.GetDevicesByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No MXP devices found for Customer Number {0}",CustomerNumber)));
            Assert.That(response.Data is IEnumerable<MxpDeviceTableEntity>);
        }

        [Test]
        async public Task GetDeviceBySysRefAsync_GivenASysRef_ReturnsADevice()
        {
            //Arrange
            var device = new MxpDeviceDetailEntity();
            const string sysRef = "sys-ref";
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns(device);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository);

            //Act
            var response = await mxpDataService.GetDeviceBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpDeviceDetailEntity);
        }

        [Test]
        async public Task GetDeviceBySysRefAsync_GivenASystemRefWhereNoDevicesExist_ReturnsEmptyListOfDevices204()
        {
            //Arrange
            const string sysRef = "sys-ref";
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns((MxpDeviceDetailEntity)null);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository);

            //Act
            var response = await mxpDataService.GetDeviceBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No device found for System Ref {0}", sysRef)));
            Assert.That(response.Data, Is.Null);
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndCrmDeviceExists_ReturnsADeviceSetsStatusToExistsCrmAndMxp()
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
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await mxpDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpDeviceDetailEntity);
            Assert.That(device.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.ExistsCrmAndMxp));
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndCrmDeviceDoesNotExist_ReturnsADeviceSetsStatusToDoesntExistInCrm()
        {
            //Arrange
            var device = new MxpDeviceDetailEntity();
            const string sysRef = "sys-ref";
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns(device);
            crmDeviceRepository
               .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
               .Returns((CrmDeviceDetailEntity)null);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await mxpDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpDeviceDetailEntity);
            Assert.That(device.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.DoesntExistInCrm));
        }

        [Test]
        async public Task GetDeviceAndStatusBySysRefAsync_GivenASysRefAndCrmDeviceExistsButWithADifferentCustomerNumber_ReturnsADeviceSetsStatusToExistsInCrmNotInMxp()
        {
            //Arrange
            var device = new MxpDeviceDetailEntity {MxpCustomerNumber = CustomerNumber};
            var crmDevice = new CrmDeviceDetailEntity {CustomerNumber = "333333"};
            const string sysRef = "sys-ref";
            var mxpDeviceRepository = CreateMxpDeviceRepository();
            var crmDeviceRepository = CreateCrmDeviceRepository();
            mxpDeviceRepository
                .GetDeviceDetailAsync(Arg.Is(sysRef))
                .Returns(device);
            crmDeviceRepository
               .GetDeviceDetailBySysRefAsync(Arg.Is(sysRef))
               .Returns(crmDevice);
            var mxpDataService = CreateMxpDataService(mxpDeviceRepository: mxpDeviceRepository, crmDeviceRepository: crmDeviceRepository);

            //Act
            var response = await mxpDataService.GetDeviceAndStatusBySysRefAsync(sysRef);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpDeviceDetailEntity);
            Assert.That(device.CrmMxpStatus, Is.EqualTo(CrmMxpStatus.ExistsInCrmNotInMxp));
        }

        [Test]
        async public Task GetContractHeadersByCustomerNumberAsync_GivenACustomerNumber_ReturnsListOfContractHeaders()
        {
            //Arrange
            var headers = new[]
            {
                new MxpContractHeaderTableEntity()
            };
            var  mxpContractsRepository = CreatMxpContractsRepository();
            mxpContractsRepository
                .GetContractHeaderTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(headers);
            var mxpDataService = CreateMxpDataService(mxpContractsRepository:mxpContractsRepository);

            //Act
            var response = await mxpDataService.GetContractHeadersByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpContractHeaderTableEntity>);
        }

        [Test]
        async public Task GetContractHeadersByCustomerNumberAsync_GivenACustomerNumberThatDoesNotReturnHeaders_ReturnsEmptyListOfContractHeaders204()
        {
            //Arrange
            var headers = new List<MxpContractHeaderTableEntity>();
            var mxpContractsRepository = CreatMxpContractsRepository();
            mxpContractsRepository
                .GetContractHeaderTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(headers);
            var mxpDataService = CreateMxpDataService(mxpContractsRepository: mxpContractsRepository);

            //Act
            var response = await mxpDataService.GetContractHeadersByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No contract headers found for customer number {0}", CustomerNumber)));
            Assert.That(response.Data is IEnumerable<MxpContractHeaderTableEntity>);
        }

        [Test]
        async public Task GetLeaseByLeaseIdAsync_GivenAleaseId_ReturnsALease()
        {
            //Arrange
            const int leaseId = 8;
            var lease = new MxpLeaseDetailEntity{ LeaseId = leaseId};
            var mxpLeaseRepository = CreateMxpLeaseRepository();
            mxpLeaseRepository
                .GetDetailEntitieAsync(leaseId)
                .Returns(lease);
            var mxpDataService = CreateMxpDataService(mxpLeaseRepository: mxpLeaseRepository);

            //Act
            var response = await mxpDataService.GetLeaseByLeaseIdAsync(leaseId);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is MxpLeaseDetailEntity);
        }

        [Test]
        async public Task GetLeaseByLeaseIdAsync_GivenAleaseIdThatDoesNotExist_ReturnsANullLease()
        {
            //Arrange
            const int leaseId = 8;
            var mxpLeaseRepository = CreateMxpLeaseRepository();
            mxpLeaseRepository
                .GetDetailEntitieAsync(leaseId)
                .Returns((MxpLeaseDetailEntity)null);
            var mxpDataService = CreateMxpDataService(mxpLeaseRepository: mxpLeaseRepository);

            //Act
            var response = await mxpDataService.GetLeaseByLeaseIdAsync(leaseId);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(404));
            Assert.That(response.Message, Is.EqualTo(string.Format("No Lease found for Lease Id {0}", leaseId)));
        }

        [Test]
        async public Task GetLeasesByCustomerNumberAsync_GivenACustomerNumber_ReturnsListOfLeases()
        {
            //Arrange
            var leases = new[]
            {
                new MxpLeaseTableEntity()
            };
            var mxpLeaseRepository = CreateMxpLeaseRepository();
            mxpLeaseRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(leases);
            var mxpDataService = CreateMxpDataService(mxpLeaseRepository: mxpLeaseRepository);

            //Act
            var response = await mxpDataService.GetLeasesByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(200));
            Assert.That(response.Message, Is.EqualTo(string.Empty));
            Assert.That(response.Data is IEnumerable<MxpLeaseTableEntity>);
        }

        [Test]
        async public Task GetLeasesByCustomerNumberAsync_GivenACustomerNumberThatDoesNotExist_ReturnsEmptyListOfLeases()
        {
            //Arrange
            var leases = new List<MxpLeaseTableEntity>();
           
            var mxpLeaseRepository = CreateMxpLeaseRepository();
            mxpLeaseRepository
                .GetTableEntitiesAsync(Arg.Is(CustomerNumber))
                .Returns(leases);
            var mxpDataService = CreateMxpDataService(mxpLeaseRepository: mxpLeaseRepository);

            //Act
            var response = await mxpDataService.GetLeasesByCustomerNumberAsync(CustomerNumber);

            //Assert
            Assert.That(response.ResponseCode, Is.EqualTo(204));
            Assert.That(response.Message, Is.EqualTo(string.Format("No leases found for customer number {0}", CustomerNumber)));
            Assert.That(response.Data is IEnumerable<MxpLeaseTableEntity>);
        }

        static MxpDataService CreateMxpDataService(IMxpCustomerRepository mxpCustomerRepository = null, 
            IMxpContactRepository mxpContactRepository = null, IMxpDeviceRepository mxpDeviceRepository = null, 
            ICrmDeviceRepository crmDeviceRepository = null, ILogWriter logWriter = null, 
            IMxpContractsRepository mxpContractsRepository = null, IMxpLeaseRepository mxpLeaseRepository = null, 
            IMxpServiceCallRepository mxpServiceCallRepository = null, ISharepointListService sharepointListService = null )
        {
            return new MxpDataService(mxpCustomerRepository ?? CreateMxpCustomerRepository(),
                mxpContactRepository ?? CreateMxpContactRepository(), mxpDeviceRepository ?? CreateMxpDeviceRepository(),
                crmDeviceRepository ?? CreateCrmDeviceRepository(), logWriter ?? CreateLogWriter(), 
                mxpContractsRepository ?? CreatMxpContractsRepository(), mxpLeaseRepository ?? CreateMxpLeaseRepository(), 
                mxpServiceCallRepository ?? CreateMxpServiceCallRepository(), sharepointListService ?? CreateSharepointListService());
        }
        static IMxpCustomerRepository CreateMxpCustomerRepository()
        {
            return Substitute.For<IMxpCustomerRepository>();
        }

        static IMxpContactRepository CreateMxpContactRepository()
        {
            return Substitute.For<IMxpContactRepository>();
        }

        static IMxpDeviceRepository CreateMxpDeviceRepository()
        {
            return Substitute.For<IMxpDeviceRepository>();
        }

        static ICrmDeviceRepository CreateCrmDeviceRepository()
        {
            return Substitute.For<ICrmDeviceRepository>();
        }

        static IMxpContractsRepository CreatMxpContractsRepository()
        {
            return Substitute.For<IMxpContractsRepository>();
        }

        static IMxpLeaseRepository CreateMxpLeaseRepository()
        {
            return Substitute.For<IMxpLeaseRepository>();
        }

        static ISharepointListService CreateSharepointListService()
        {
            return Substitute.For<ISharepointListService>();
        }


        static IMxpServiceCallRepository CreateMxpServiceCallRepository()
        {
            return Substitute.For<IMxpServiceCallRepository>();
        }
        static ILogWriter CreateLogWriter()
        {
            return Substitute.For<ILogWriter>();
        }
    }

}
