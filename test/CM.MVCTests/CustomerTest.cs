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
        public void Should()
        {
            var controller = new CustomerController();
            var countries = (controller.Index(1) as ViewResult).Model as PagedList<Customer>;
            Assert.Equal("Alex",countries[0].firstName);
        }

        [Fact]
        public void ShouldNotBeViewResultType()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);
            controller.Create();
            var customer = new Customer()
            {
                firstName = "Matvej",
                lastName = "Levantsou",
                email = "leva@gmail.com",
                notes = "123123",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 12
            };
            var customers = controller.Create(customer)  as RedirectToRouteResult;

            customerRepositoryMock.Verify(x => x.Create(customer));

            Assert.NotNull(customers);
        }

        [Fact]
        public void ShouldDoDetails()
        {
            var controller = new CustomerController();
            var customers = (controller.Details(1) as ViewResult).Model as Customer;

            Assert.Equal("Alex", customers.firstName);
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
            Assert.NotNull(customers);
            
        }
        [Fact]
        public void ShouldDoDelete()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);
            var customers = controller.Delete(2) as RedirectToRouteResult;
            customerRepositoryMock.Verify(x => x.Delete(2));
            Assert.NotNull(customers);
        }
        [Fact]
        public void ShouldDoDeleteBadRequest()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);
            var result = controller.Delete(null) as HttpStatusCodeResult;
            Assert.Equal(new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }

        [Fact]
        public void ShouldDoDetailsHttpStatusCodeResult()
        {
            var controller = new CustomerController();
            var result = controller.Details(null) as HttpStatusCodeResult;
            Assert.Equal(new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode, result.StatusCode);
        }

        [Fact]
        public void ShouldDoHttpNotFoundDetails()
        {
            var controller = new CustomerController();
            var result = controller.Details(1000) as HttpNotFoundResult;
            Assert.Equal(new HttpNotFoundResult().StatusCode, result.StatusCode);
        }

        [Fact]
        public void ShouldDoHttpNotFoundEdit()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var controller = new CustomerController(customerRepositoryMock.Object);
            //var result = controller.Edit(null) as HttpNotFoundResult;
        }
    }
}
