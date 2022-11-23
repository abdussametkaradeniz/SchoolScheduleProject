using Autofac;
using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;

namespace Bussiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //configurasyonu burada yapıyoruz
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EnFraCustomerDao>().As<ICustomerDao>();

            builder.RegisterType<ClassesManager>().As<IClassesService>();
            builder.RegisterType<EnFraClassesDao>().As<IClassesDao>();

            builder.RegisterType<CustomersAndSchoolManager>().As<ICustomersAndSchoolService>();
            builder.RegisterType<EnFraCustomersAndSchoolDao>().As<ICustomerAndSchoolDao>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
