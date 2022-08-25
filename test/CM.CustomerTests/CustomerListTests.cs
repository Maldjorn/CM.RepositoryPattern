using CM.Customers;
using CustomerWebForm;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CM.CustomerTests
{
    public class CustomerListTests
    {
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var repository = new Mock<IRepository<Customer>>();
            repository.Setup(x => x.GetAll()).Returns( () => new List<Customer>()
            {
                new Customer(),
                new Customer()
            });
            var customerList = new CustomerList(repository.Object);

            customerList.LoadCustomerFromDatabase();
            Assert.Equal(2, customerList.customers.Count);
            Assert.NotNull(repository);
        }
    }
}
