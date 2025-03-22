using CleaningEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface IParameterService
    {
        SupplierParameter GetSupplierParameter(int userId);
        void AddSupplierParemeter(SupplierParameter supplierParameter);
        void Update(SupplierParameter supplierParameter);
    }
}
