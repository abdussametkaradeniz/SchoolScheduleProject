using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Bussiness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomersAndSchoolManager:ICustomersAndSchoolService
    {
        private ICustomerAndSchoolDao _customerAndSchoolDao;

        public CustomersAndSchoolManager(ICustomerAndSchoolDao customerAndSchoolDao)
        {
            _customerAndSchoolDao = customerAndSchoolDao;
        }
        public IDataResult<CustomersAndSchoolDtos> GetById(string CustomerAndSchool_Id)
        {
            return new SuccessDataResult<CustomersAndSchoolDtos>(_customerAndSchoolDao.Get(p => p.CustomerAndSchool_Id == CustomerAndSchool_Id));
        }

     
    }
}
