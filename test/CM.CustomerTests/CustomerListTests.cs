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
            var repository = new Mock<IRepository<Country>>();
            repository.Setup(x => x.GetAll()).Returns(() => new List<Country>()
            {
                new Country(),
                new Country()
            });
            var cutomerList = new CustomerList
            customers = repository.GetAll();
            Assert.Equal(8, customers.Count);
            Assert.NotNull(repository);
        }
    }
}
