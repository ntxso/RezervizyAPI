using CleaningEntities;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DACleaning.Abstract;
using DACleaning.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DACleaning.Concrete.EntityFramework
{
    public class EfAddressDal : EfEntityRepositoryBase<AddressCustomer, NtxsoContext>, IAddressDal
    {
    }

    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NtxsoContext>, ICustomerDal
    {


        public List<CustomerDto> GetCustomersDto(int supplierId = 0)
        {
            using (var context = new NtxsoContext())
            {
                var result = from customer in context.Customers
                             join address in context.Addresses
                             on customer.Id equals address.CustomerId
                             where customer.SupplierId == supplierId
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 Name = customer.Name,
                                 PhoneNumber = customer.PhoneNumber,
                                 CityId = address.CityId,
                                 DistrictId = address.DistrictId,
                                 QuarterId = address.QuarterId,
                                 Address = address.Address
                             };
                return result.ToList();
            }

        }

        public List<CustomerDto> GetCustomersDtoByName(string name, int supplierId = 0)
        {
            using (var context = new NtxsoContext())
            {
                var result = from customer in context.Customers
                             join address in context.Addresses
                             on customer.Id equals address.CustomerId
                             where customer.Name.Contains(name) && customer.SupplierId == supplierId
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 Name = customer.Name,
                                 PhoneNumber = customer.PhoneNumber,
                                 CityId = address.CityId,
                                 DistrictId = address.DistrictId,
                                 QuarterId = address.QuarterId,
                                 Address = address.Address
                             };
                return result.ToList();
            }



        }

        public List<CustomerDto> GetCustomersDtoByPhoneNumber(string phoneNumber, int supplierId = 0)
        {
            using (var context = new NtxsoContext())
            {
                var result = from customer in context.Customers
                             join address in context.Addresses
                             on customer.Id equals address.CustomerId
                             where customer.PhoneNumber.Contains(phoneNumber) && customer.SupplierId == supplierId
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 Name = customer.Name,
                                 PhoneNumber = customer.PhoneNumber,
                                 CityId = address.CityId,
                                 DistrictId = address.DistrictId,
                                 QuarterId = address.QuarterId,
                                 Address = address.Address
                             };
                return result.ToList();
            }
        }

        public CustomerDto GetCustomerDtoById(int customerId)
        {
            using (var context = new NtxsoContext())
            {
                var result = from customer in context.Customers
                             join address in context.Addresses
                             on customer.Id equals address.CustomerId
                             where customer.Id == customerId
                             select new CustomerDto
                             {
                                 CustomerId = customer.Id,
                                 Name = customer.Name,
                                 PhoneNumber = customer.PhoneNumber,
                                 CityId = address.CityId,
                                 DistrictId = address.DistrictId,
                                 QuarterId = address.QuarterId,
                                 Address = address.Address
                             };
                return result.Single();
            }
        }
    }
    public class EfCustomerNoteDal : EfEntityRepositoryBase<CustomerNote, NtxsoContext>, ICustomerNoteDal
    {
    }
    public class EfOrderDal : EfEntityRepositoryBase<Order, NtxsoContext>, IOrderDal
    {
        public List<Order> GetOrdersFromSupplierId(int supplierId)
        {
            using(var context=new NtxsoContext())
            {
                var result = from order in context.Orders
                             join customer in context.Customers
                             on order.CustomerId equals customer.Id
                             where customer.SupplierId == supplierId
                             select order;
                return result.ToList();
            }
        }
    }
    public class EfOrderRowDal : EfEntityRepositoryBase<OrderRow, NtxsoContext>, IOrderRowDal
    {
    }
    public class EfProductDal : EfEntityRepositoryBase<Product, NtxsoContext>, IProductDal
    {
    }


    public class EfUserDal : EfEntityRepositoryBase<User, NtxsoContext>, IUserDal
    {

        public List<User> GetUsersFromRole(string role)
        {
            using (var context = new NtxsoContext())
            {
                var temp = context.OperationClaims.Where(p => p.Name == role).FirstOrDefault();
                int roleId = (temp != null) ? temp.Id : 0;
                var result = from user in context.Users
                             join userOpClaim in context.UserOperationClaims
                             on user.Id equals userOpClaim.UserId
                             where userOpClaim.OperationClaimId == roleId
                             select user;

                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NtxsoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public void AddUserOperationClaim(User user, int operationId)
        {
            var claimList = GetClaims(user);
            if (claimList.Any(p => p.Id == operationId))
            {
                return;
            }
            using (var context = new NtxsoContext())
            {
                context.UserOperationClaims.Add(new UserOperationClaim
                {
                    OperationClaimId = operationId,
                    UserId = user.Id
                });
                context.SaveChanges();
            }
        }

        public OperationClaim GetOperationClaimByName(string claimName)
        {
            OperationClaim claim;
            using (var context = new NtxsoContext())
            {
                claim = context.OperationClaims.Where(p => p.Name == claimName).FirstOrDefault();
            }
            if (claim != null)
            {
                return claim;
            }
            else
            {
                return new OperationClaim() { Name = "undefined" };
            }
        }

    }


}
