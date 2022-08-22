using System;
using Xunit;
using CM.Customers.Repositories;
using CM.Customers;

namespace CM.CustomerTests
{
    public class CustomerTests
    {
        CustomerRepositoryFixture Fixture = new CustomerRepositoryFixture();
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Fixture.DeleteAll();
            var repository = new CustomerRepository();
            var customer = new Customer()
            {
                firstName = "qqe",
                lastName = "www",
                email = "example@example.com",
                notes = "qweqweqweqweqwe",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 123
            };
            repository.Create(customer);
        }

        [Fact]
        public void ShouldBeAbleToDelete()
        {
            var repository = new CustomerRepository();
           repository.Delete(1);
        }
        [Fact]
        public void ShouldBeAbleToRead()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository.Read(repository.GetID()));
        }

        [Fact]
        public void ShouldBeAbleToUpdate()
        {
            var repository = new CustomerRepository();
            var customer = new Customer()
            {
                firstName = "www",
                lastName = "qqq",
                email = "prikol@example.com",
                notes = "qweqweqweqweqwe",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 123,
                customerID = 2
                
            };
            repository.Update(customer);
        }

        [Fact]
        public void ShouldBeAbleGetID()
        {
            
        }

    }
    public class CustomerRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }
    }

}
