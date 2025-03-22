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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Order>> GetList(int? supplierId = null)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetOrdersFromSupplierId(supplierId ?? 0)
                .OrderByDescending(p => p.DeliveryDate).ToList());
        }
        public IDataResult<List<Order>> GetList(DateTime date, int? supplierId = null)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetOrdersFromSupplierId(supplierId ?? 0)
                .Where(p => p.DeliveryDate >= date.Date)
                .OrderByDescending(p => p.DeliveryDate).ToList());
        }
        public IDataResult<List<Order>> GetListByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetList(p => p.CustomerId == customerId)
                .OrderByDescending(p => p.DeliveryDate).ToList());
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.Uptated);
        }
        public IDataResult<Order> GetByOrderId(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(p => p.OrderId == orderId));
        }

        public IDataResult<List<Order>> GetList(DateTime dateFirst, DateTime dateLast, int? supplierId = null)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetOrdersFromSupplierId(supplierId ?? 0)
                .Where(p => p.DeliveryDate >= dateFirst.Date && p.DeliveryDate <= dateLast.Date.Add(new TimeSpan(23,59,59)))
                .OrderByDescending(p => p.DeliveryDate).ToList());
        }
    }
}
