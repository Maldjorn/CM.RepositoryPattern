﻿using ASPMVC.Controllers;
using CM.Customers;
using CM.Customers.Entities;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CM.MVCTests
{
    public class AddressTest
    {
        [Fact]
        public void SgouldDoIndex()
        {
            var addressController = new AddressController();
            var result = (addressController.Index() as ViewResult).Model as List<Address>;
            Assert.True(result.Exists(x => x.AddressLine == "Address3"));
        }
        [Fact]
        public void ShouldDoCreateAddress()
        {
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var addressController = new AddressController(addressRepositoryMock.Object);
            addressController.Create();
            var address = new Address()
            {
                CustomerID = 1,
                AddressLine = "address1",
                AddressLine2 = "address2",
                AddressType = 2,
                City = "city",
                Country = "Canada",
                PostalCode = "1221",
                State = "State"
            };

            var result = addressController.Create(address);
            addressRepositoryMock.Verify(x => x.Create(address));
        }
        [Fact]
        public void ShouldDoEditBadrequest()
        {
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var addressController = new AddressController(addressRepositoryMock.Object);
            var result = addressController.Edit(null) as HttpStatusCodeResult;
            var expectedResult = new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode;
            Assert.Equal(expectedResult, result.StatusCode);
        }

        [Fact]
        public void ShouldDoEditHttpNotFound()
        {
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var addressController = new AddressController(addressRepositoryMock.Object);
            var result = addressController.Edit(1000) as HttpNotFoundResult;
            var expectedResult = new HttpNotFoundResult().StatusCode;
            Assert.Equal(expectedResult, result.StatusCode);
        }

        [Fact]
        public void ShouldDoEditview()
        {
            var addressController = new AddressController();
            var result = addressController.Edit(1) as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldDoCreateHttpNotFound()
        {
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var addressController = new AddressController(addressRepositoryMock.Object);
            Address address = null;
            var result = addressController.Create(address) as HttpNotFoundResult;
            var expectedResult = new HttpNotFoundResult().StatusCode;
            Assert.Equal(expectedResult, result.StatusCode);
        }

        [Fact]
        public void ShouldDoDetails()
        {
            var addressController = new AddressController();
            var result = (addressController.Details(1) as ViewResult).Model as Address;
            Assert.Equal("Address", result.AddressLine);
        }

        [Fact]
        public void ShouldDoDetailsBadrequest()
        {
            var addressController = new AddressController();
            var result = (addressController.Details(null) as HttpStatusCodeResult);
            var expectedResult = new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest).StatusCode;
            Assert.Equal(expectedResult, result.StatusCode);
        }
        [Fact]
        public void ShouldDoDetailsHttpNotFound()
        {
            var addressController = new AddressController();
            var result = (addressController.Details(100) as HttpNotFoundResult);
            var expectedResult = new HttpNotFoundResult().StatusCode;
            Assert.Equal(expectedResult,result.StatusCode);
        }

    }
}
