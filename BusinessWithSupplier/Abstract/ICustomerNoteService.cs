using CleaningEntities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface ICustomerNoteService
    {
        IDataResult<CustomerNote> GetByCustomerId(int customerId);
        IResult Add(CustomerNote customerNote);
        IResult Update(CustomerNote customerNote);
        IResult Delete(CustomerNote customerNote);
    }
}
