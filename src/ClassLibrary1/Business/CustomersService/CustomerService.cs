using CM.Customers.Business.CustomersService;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;

namespace CM.Customers.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public CustomerService()
        {
            _customerRepository = new CustomerRepository(connectionString);
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

        Customer ICustomerService.Read(int? entityCode)
        {
            if (entityCode == null)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }

            Customer customer;
            int tries = 0;
            while (true)
            {
                try
                {
                    customer = _customerRepository.Read(entityCode);
                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;
                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }
            if (customer == null)
            {
                throw new CodeNotFoundException();
            }
            return customer;
        }

        void ICustomerService.Update(Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.GetType().Name);
            }
            _customerRepository.Update(entity);
        }

        void ICustomerService.Delete(int entityCode)
        {
            if (entityCode == 0)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }
            _customerRepository.Delete(entityCode);
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers;

            int tries = 0;
            while (true)
            {
                try
                {
                    customers = _customerRepository.GetAll();
                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;
                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }
            if (customers == null)
            {
                throw new NullReferenceException();
            }
            return customers;
        }

        public List<Customer> GetAll(int? entityCode)
        {
            if (entityCode == null)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }

            List<Customer> customers;

            int tries = 0;
            while (true)
            {
                try
                {
                    customers = _customerRepository.GetAll(entityCode);
                    break;
                }
                catch (TimeoutException e)
                {
                    tries++;
                    if (tries > 3)
                    {
                        throw e;
                    }
                }
            }
            if (customers == null)
            {
                throw new NullReferenceException();
            }
            return customers;
        }

       
    }
}
