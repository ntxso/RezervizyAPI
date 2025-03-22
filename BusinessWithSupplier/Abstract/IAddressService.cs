using CleaningEntities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<AddressCustomer>> GetList();
        IDataResult<AddressCustomer> GetByCustomerId(int Id);
        
        IResult Add(AddressCustomer address);
        IResult Update(AddressCustomer address);
        IResult Delete(AddressCustomer address);

    }
}
