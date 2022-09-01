using ASPMVC.Controllers;
using CM.Customers;
using Moq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CM.MVCTests
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldReturnCustomerList()
        {
            var controller = new CustomerController();
            var countries = (controller.Index(1) as ViewResult).Model as PagedList<Customer>;
            Assert.Equal("qqqqqq",countries[0].firstName);
        }

        [Fact]
        public void ShouldNotBeViewResultType()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);

            var customers = controller.Create( new Customer() 
            { 
                firstName  = "Matvej",
                lastName = "Levantsou",
                email = "leva@gmail.com",
                notes = "123123",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 12
            }) as RedirectToRouteResult;

            Assert.NotNull(customers);
        }

        [Fact]
        public void ShouldDoDeatils()
        {
            var controller = new CustomerController();
            var customers = (controller.Details(1444) as ViewResult).Model as Customer;

            Assert.Equal("Ivan", customers.firstName);
        }

        [Fact]
        public void ShouldDoEdit()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);

            var customers = controller.Edit(new Customer()
            {
                firstName = "Matvej",
                lastName = "Levantsou",
                email = "leva@gmail.com",
                notes = "123123",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 12
            }) as RedirectToRouteResult;

            customerRepositoryMock.Verify(x => x.Update(It.IsAny<Customer>()));
        }
    }
}
