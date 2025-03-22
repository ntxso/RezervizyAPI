using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Constants;
using CleaningEntities;
using Core.Utilities.Result;
using CoreNT.Utilities;
using DACleaning.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        int supplierId;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<int> Add(Customer customer, int? supplierId = null)
        {
            customer.Name = customer.Name.ToUpper();
            customer.PhoneNumber = customer.PhoneNumber.TrimPhoneNumber();
            if (customer.SupplierId == 0)
            {
                customer.SupplierId = supplierId ?? 0;
            }
            _customerDal.Add(customer);
            return new SuccessDataResult<int>(customer.Id);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Customer> GetCustomerById(int Id)
        {
            Customer cust = _customerDal.Get(p => p.Id == Id);
            if (cust != null)
            {
                return new SuccessDataResult<Customer>(cust);
            }
            return new ErrorDataResult<Customer>(cust);
        }

        public IDataResult<CustomerDto> GetCustomerDtoById(int Id)
        {
            return new SuccessDataResult<CustomerDto>(_customerDal.GetCustomerDtoById(Id));
        }



        public IDataResult<List<CustomerDto>> GetCustomersDto(int? supplierId = null)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetCustomersDto(supplierId ?? 0));
            //.OrderByDescending(P=>P.CustomerId).Take(20).ToList());
        }


        public IDataResult<List<CustomerDto>> GetCustomersDtoByPhoneNumber(string phoneNumber, int? supplierId = null)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetCustomersDtoByPhoneNumber(phoneNumber, supplierId ?? 0));
        }
        public IDataResult<List<CustomerDto>> GetCustomersDtoByName(string name, int? supplierId = null)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetCustomersDtoByName(name, supplierId ?? 0));
        }

        //****************  Düzeltme yap son kayıtlar geliyor !!!!!!!!!!!
        public IDataResult<List<Customer>> GetList(int? supplierId = null)
        {
            supplierId = supplierId ?? 0;
            return new SuccessDataResult<List<Customer>>(_customerDal.GetList(p => p.SupplierId == supplierId).ToList());
            //.OrderByDescending(p=>p.Id).Take(20).ToList());
        }

        public IDataResult<List<Customer>> GetListByName(string name, int? supplierId = null)
        {
            supplierId = supplierId ?? 0;
            return new SuccessDataResult<List<Customer>>(_customerDal
                .GetList(p => p.Name.Contains(name) && p.SupplierId == supplierId).ToList());
        }
        public IDataResult<List<Customer>> GetListByPhoneNumber(string phoneNumber, int? supplierId = null)
        {
            supplierId = supplierId ?? 0;
            return new SuccessDataResult<List<Customer>>(_customerDal
                .GetList(p => p.PhoneNumber.Contains(phoneNumber) && p.SupplierId == supplierId).ToList());
        }
        public IResult Update(Customer customer)
        {
            customer.Name = customer.Name.ToUpper();
            customer.PhoneNumber = customer.PhoneNumber.TrimPhoneNumber();
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Uptated);
        }

        public IDataResult<Customer> GetLastCustomer(int? supplierId = null)
        {
            if (supplierId == null) supplierId = 0;

            return new SuccessDataResult<Customer>(_customerDal.
                GetList(p => p.SupplierId == supplierId).
                OrderByDescending(k => k.Id).FirstOrDefault());
        }
    }
}
