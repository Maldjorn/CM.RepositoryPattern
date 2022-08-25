using CM.Customers;
using CustomerWebForm;
using Moq;
using System;
using Xunit;

namespace CM.WebFormsTests
{
    public class CreateTest
    {
        [Fact]
        public void ShouldbeAbleToCreate()
        {
            var repository = new Mock<IRepository<Customer>>();
            var customerEdit = new CustomerEdit(repository.Object);
            customerEdit.EditButton_Click(this, EventArgs.Empty);
            repository.Verify(x => x.Create(It.IsAny<Customer>()));
        }
    }
}
