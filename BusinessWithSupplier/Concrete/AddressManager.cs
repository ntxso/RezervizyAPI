using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Constants;
using CleaningEntities;
using Core.Utilities.Result;
using DACleaning.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public IResult Add(AddressCustomer address)
        {
            address.Address = address.Address.ToUpper();
            _addressDal.Add(address);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(AddressCustomer address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<AddressCustomer> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<AddressCustomer>(_addressDal.Get(p => p.CustomerId == CustomerId));
        }

        public IDataResult<List<AddressCustomer>> GetList()
        {
            return new SuccessDataResult<List<AddressCustomer>>(_addressDal.GetList().ToList());
        }

        public IResult Update(AddressCustomer address)
        {
            address.Address = address.Address.ToUpper();
            _addressDal.Update(address);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
