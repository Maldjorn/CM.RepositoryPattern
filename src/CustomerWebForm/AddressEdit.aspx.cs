using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;

namespace CustomerWebForm
{
    public partial class AddressEdit : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IRepository<Address> _addressRepository;
        public IRepository<Customer> _customerRepository;
        public AddressEdit()
        {
            _addressRepository = new AddressRepository(connectionString);
            _customerRepository = new CustomerRepository(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var addresses_ID = _customerRepository.GetAllId();
            foreach (var item in addresses_ID)
            {
                drpDwnList.Items.Add(item.ToString());
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            var address = new Address()
            {
                CustomerID = Convert.ToInt32(drpDwnList.SelectedValue),
                AddressLine = addressLineTextBox.Text,
                AddressLine2 = addressLine2TextBox.Text,
                AddressType = Convert.ToInt32(addressTypeTextBox.Text),
                City = cityTextBox.Text,
                PostalCode = postalCodeTextBox.Text,
                State = stateTextBox.Text,
                Country = countryTextBox.Text
            };
            _addressRepository.Create(address);
            Response.Redirect("AddressesList.aspx");
        }
    }
}