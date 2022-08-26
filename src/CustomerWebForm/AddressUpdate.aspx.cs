using CM.Customers;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerWebForm
{
    public partial class AddressUpdate : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IRepository<Address> _addressRepository;

        public AddressUpdate()
        {
            _addressRepository = new AddressRepository(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var addressIdReq = Convert.ToInt32(Request.QueryString["address_ID"]);
                var addresses_ID = _addressRepository.GetAllId();
                foreach (var item in addresses_ID)
                {
                    drpDwnList.Items.Add(item.ToString());
                }
                if (addressIdReq != 0)
                {
                    var addresses = _addressRepository.Read(addressIdReq);
                    addressLineTextBox.Text = addresses.AddressLine;
                    addressLine2TextBox.Text = addresses.AddressLine2;
                    addressTypeTextBox.Text = addresses.AddressType.ToString();
                    cityTextBox.Text = addresses.City;
                    postalCodeTextBox.Text = addresses.PostalCode;
                    stateTextBox.Text = addresses.State;
                    countryTextBox.Text = addresses.Country;
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            var address = new Address()
            {
                AddressID = Convert.ToInt32(Request.QueryString["address_ID"]),
                CustomerID = Convert.ToInt32(drpDwnList.SelectedValue),
                AddressLine = addressLineTextBox.Text,
                AddressLine2 = addressLine2TextBox.Text,
                AddressType = Convert.ToInt32(addressTypeTextBox.Text),
                City = cityTextBox.Text,
                PostalCode = postalCodeTextBox.Text,
                State = stateTextBox.Text,
                Country = countryTextBox.Text
            };
            _addressRepository.Update(address);
            Response.Redirect("AddressesList.aspx");
        }
    }
}