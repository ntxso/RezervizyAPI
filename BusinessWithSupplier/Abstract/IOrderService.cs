using CleaningEntities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetList(int? supplierId = null);
        IDataResult<List<Order>> GetList(DateTime date, int? supplierId = null);
        IDataResult<List<Order>> GetList(DateTime dateFirst, DateTime dateLast, int? supplierId = null);
        IDataResult<List<Order>> GetListByCustomerId(int customerId);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);
        IDataResult<Order> GetByOrderId(int orderId);
    }
}
