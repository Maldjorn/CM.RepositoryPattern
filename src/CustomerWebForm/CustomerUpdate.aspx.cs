using CM.Customers;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerWebForm
{
    public partial class CustomerUpdate : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IRepository<Customer> _repository;
        public CustomerUpdate()
        {
            _repository = new CustomerRepository(connectionString);
        }
        public CustomerUpdate(IRepository<Customer> customer)
        {
            _repository = customer;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customer_ID"]);
            if (customerIdReq != 0)
            {
                var customer = _repository.Read(customerIdReq);
                firstNameTextBox.Text = customer.firstName;
                lastNameTextBox.Text = customer.lastName;
                phoneNumberTextBox.Text = customer.phoneNumber;
                emailTextBox.Text = customer.email;
                notesTextBox.Text = customer.notes;
                amountTextBox.Text = customer.totalPurchaseAmount.ToString();

            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                customerID = Convert.ToInt32(Request.QueryString["customer_ID"]),
                firstName = firstNameTextBox?.Text,
                lastName = lastNameTextBox?.Text,
                phoneNumber = phoneNumberTextBox?.Text,
                email = emailTextBox?.Text,
                notes = notesTextBox?.Text,
                totalPurchaseAmount = Convert.ToDecimal(amountTextBox?.Text)
            };
            if (Convert.ToInt32(Request.QueryString["customer_ID"]) != 0)
            {
                _repository.Update(customer);
            }
            Response.Redirect("CustomerList.aspx");
        }
    }
}