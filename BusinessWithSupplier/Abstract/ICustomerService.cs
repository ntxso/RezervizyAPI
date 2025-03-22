using CleaningEntities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetList(int? supplierId = null);
        IDataResult<List<Customer>> GetListByName(string name, int? supplierId = null);
        IDataResult<Customer> GetCustomerById(int Id);
        IDataResult<Customer> GetLastCustomer(int? supplierId=null);
        IDataResult<List<Customer>> GetListByPhoneNumber(string phoneNumber, int? supplierId = null);
        IDataResult<int> Add(Customer customer, int? supplierId = null);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<CustomerDto>> GetCustomersDto(int? supplierId = null);
        IDataResult<List<CustomerDto>> GetCustomersDtoByName(string name, int? supplierId = null);
        IDataResult<List<CustomerDto>> GetCustomersDtoByPhoneNumber(string phoneNumber, int? supplierId = null);
        IDataResult<CustomerDto> GetCustomerDtoById(int Id);
    }
}
