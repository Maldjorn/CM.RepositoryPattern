using CM.Customers.Entities;
using CM.Customers.Repositories;
using Xunit;

namespace CM.CustomerTests
{
    public class AddressTests
    {
        AddressRepositoryFixture fixture = new AddressRepositoryFixture();
        [Fact]
        public void ShouldBeableToCreateAddressObject()
        {
            var addressRepository = new AddressRepository();
            Assert.NotNull(addressRepository);
        }

        [Fact]
        public void ShouldBeableToCreate()
        {
            var addressRepository = new AddressRepository();
            fixture.DeleteAll();
            Address address = new Address()
            {
                CustomerID = addressRepository.GetCustomerID(),
                AddressLine = "qqqqq",
                AddressLine2 = "wwwww",
                AddressType = 1,
                City = "city",
                Country = "United States",
                PostalCode = "111",
                State = "State"

            };
            addressRepository.Create(address);
        }

        [Fact]
        public void ShouldBeableToUpdate()
        {
            var addressRepository = new AddressRepository();
            Address address = new Address()
            {
                AddressID = addressRepository.GetID(),
                CustomerID = addressRepository.GetCustomerID(),
                AddressLine = "wwwww",
                AddressLine2 = "wqqwewwqww",
                AddressType = 1,
                City = "qweqweqwasdasdqw",
                Country = "United States",
                PostalCode = "111",
                State = "State"

            };
            addressRepository.Update(address);
        }
        [Fact]
        public void ShouldBeAbleToDelete()
        {
            var addressRepository = new AddressRepository();
            //addressRepository.Delete(126);
        }
        [Fact]
        public void ShouldBeAbleToRead()
        {
            var addressRepository = new AddressRepository();
            Assert.NotNull(addressRepository.Read(123));
        }
    }
    public class AddressRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new AddressRepository();
            repository.DeleteAll();
        }
    }
}
