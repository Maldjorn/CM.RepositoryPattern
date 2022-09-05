using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Customers.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return customer;
        }
    }
}
