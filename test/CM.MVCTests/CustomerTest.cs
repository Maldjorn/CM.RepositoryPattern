using ASPMVC.Controllers;
using CM.Customers;
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
            var countries = (controller.Index() as ViewResult).Model as List<Customer>;
            Assert.True(countries.Exists(x => x.customerID == 294));
        }

        [Fact]
        public void ShouldNotBeViewResultType()
        {
            var controller = new CustomerController();
            var customers = controller.Create( new Customer() 
            { 
                firstName  = "Matvej",
                lastName = "Levantsou",
                email = "leva@gmail.com",
                notes = "123123",
                phoneNumber = "165204892561322",
                totalPurchaseAmount = 12
            });

            Assert.IsNotType<ViewResult>(customers);
        }

        [Fact]
        public void ShouldreturnDetaills()
        {
            var controller = new CustomerController();
            var customers = (controller.Details(1444) as ViewResult).Model as Customer;

            Assert.Equal("Ivan", customers.firstName);
        }
    }
}
