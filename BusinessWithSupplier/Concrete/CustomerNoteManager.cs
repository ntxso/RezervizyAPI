using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Constants;
using CleaningEntities;
using Core.Utilities.Result;
using DACleaning.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class CustomerNoteManager : ICustomerNoteService
    {
        private ICustomerNoteDal _customerNoteDal;
        public CustomerNoteManager(ICustomerNoteDal customerNoteDal)
        {
            _customerNoteDal = customerNoteDal;
        }
        public IResult Add(CustomerNote customerNote)
        {
            _customerNoteDal.Add(customerNote);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CustomerNote customerNote)
        {
            _customerNoteDal.Delete(customerNote);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CustomerNote> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CustomerNote>(_customerNoteDal.Get(p => p.CustomerId == customerId));
        }

        public IResult Update(CustomerNote customerNote)
        {
            _customerNoteDal.Update(customerNote);
            return new SuccessResult(Messages.Uptated);
        }
    }
}
