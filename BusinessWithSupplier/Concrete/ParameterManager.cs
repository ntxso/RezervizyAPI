using BusinessWithSupplier.Abstract;
using CleaningEntities;
using DACleaning.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class ParameterManager : IParameterService
    {
        public void AddSupplierParemeter(SupplierParameter supplierParameter)
        {
            using (var context = new NtxsoContext())
            {
                context.SupplierDefault.Add(supplierParameter);
                context.SaveChanges();
            }
        }

        public SupplierParameter GetSupplierParameter(int userId)
        {
            using (var context = new NtxsoContext())
            {
                return context.SupplierDefault.Where(dd => dd.UserId == userId).SingleOrDefault();
            }
        }

        public void Update(SupplierParameter supplierParameter)
        {
            using (var context = new NtxsoContext())
            {
                context.SupplierDefault.Update(supplierParameter);
                context.SaveChanges();
            }
        }
    }
}
