using CM.Addresss.Business;
using CM.Customers;
using CM.Customers.Business;
using CM.Customers.Entities;
using CM.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Addresss.Business
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        readonly string connectionString = @"Data Source=DESKTOP-JDONGM6\SQLEXPRESS;Database=CustomerLib_Timoschenko_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public AddressService()
        {
            _addressRepository = new AddressRepository(connectionString);
        }

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Address Create(Address address)
        {
            _addressRepository.Create(address);

            return address;
        }

        Address IAddressService.Read(int? entityCode)
        {
            if (entityCode == null)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }

            Address Address;
            int tries = 0;
            while (true)
            {
                try
                {
                    Address = _addressRepository.Read(entityCode);
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
            if (Address == null)
            {
                throw new CodeNotFoundException();
            }
            return Address;
        }

        void IAddressService.Update(Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.GetType().Name);
            }
            _addressRepository.Update(entity);
        }

        void IAddressService.Delete(int entityCode)
        {
            if (entityCode == 0)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }
            _addressRepository.Delete(entityCode);
        }

        public List<Address> GetAll()
        {
            List<Address> Addresss;

            int tries = 0;
            while (true)
            {
                try
                {
                    Addresss = _addressRepository.GetAll();
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
            if (Addresss == null)
            {
                throw new NullReferenceException();
            }
            return Addresss;
        }

        public List<Address> GetAll(int? entityCode)
        {
            if (entityCode == null)
            {
                throw new ArgumentNullException(entityCode.ToString());
            }

            List<Address> Addresss;

            int tries = 0;
            while (true)
            {
                try
                {
                    Addresss = _addressRepository.GetAll(entityCode);
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
            if (Addresss == null)
            {
                throw new NullReferenceException();
            }
            return Addresss;
        }
    }
}
