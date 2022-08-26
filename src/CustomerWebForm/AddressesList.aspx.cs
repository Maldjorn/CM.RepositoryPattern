﻿using CM.Customers;
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
    public partial class AddressesList : System.Web.UI.Page
    {
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Address> addresses { get; set; } = new List<Address>();
        public IRepository<Address> _repository;
        public AddressesList()
        {
            _repository = new AddressRepository(connectionString);
        }
        public AddressesList(IRepository<Address> customer)
        {
            _repository = customer;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFromDatabase();
        }

        public void LoadFromDatabase()
        {
            addresses = _repository.GetAll();
        }
    }
}