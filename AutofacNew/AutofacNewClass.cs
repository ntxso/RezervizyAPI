using Autofac;
using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Concrete;
using BusinessWithSupplier.Logging.Concrete;
using Core.Utilities.Security.Jwt;
using DACleaning.Abstract;
using DACleaning.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacNew
{
    public class AutofacNewClass:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<CustomerNoteManager>().As<ICustomerNoteService>();
            builder.RegisterType<EfCustomerNoteDal>().As<ICustomerNoteDal>();

            builder.RegisterType<CdqManager>().As<ICdqService>();

            builder.RegisterType<LoggingBusiness>().As<ILoggingServices>();
            builder.RegisterType<LogToSqlServer>().As<BusinessWithSupplier.Logging.Abstract.ILog>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHepler>().As<ITokenHelper>();

        }
    }
}
