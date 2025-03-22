using CleaningEntities;
using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DACleaning.Abstract
{
    public interface IAddressDal : IEntityRepository<AddressCustomer>
    {
    }
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDto> GetCustomersDto(int supplierId = 0);
        List<CustomerDto> GetCustomersDtoByName(string name, int supplierId = 0);
        List<CustomerDto> GetCustomersDtoByPhoneNumber(string phoneNumber, int supplierId = 0);
        CustomerDto GetCustomerDtoById(int id);

    }
    public interface ICustomerNoteDal : IEntityRepository<CustomerNote>
    {
    }

    public interface IOrderDal : IEntityRepository<Order>
    {
        List<Order> GetOrdersFromSupplierId(int supplierId);
    }

    public interface IOrderRowDal : IEntityRepository<OrderRow>
    {
    }

    public interface IProductDal : IEntityRepository<Product>
    {

    }

    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        void AddUserOperationClaim(User user, int operationId);
        List<User> GetUsersFromRole(string role);
        OperationClaim GetOperationClaimByName(string claimName);
    }


}
