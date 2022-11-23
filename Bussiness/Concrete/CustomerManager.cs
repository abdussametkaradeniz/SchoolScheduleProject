using Bussiness.Abstract;
using Bussiness.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        //kodlarını yazarken elinden geldiğince nesne üretmeden yaz.
        private ICustomerDao _customerDao; 

        public CustomerManager(ICustomerDao customerDao)
        {
            _customerDao = customerDao;
        }

        //bütün işlemlerimi artık burada yapacağım. ifler falan hep burada yazılacak
        public IResult Add(CustomerDto customer)
        {
            _customerDao.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(CustomerDto customer)
        {
            _customerDao.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<CustomerDto> GetById(int CustomerId)
        {
            return new SuccessDataResult<CustomerDto>(_customerDao.Get(p => p.CustomerId == CustomerId));
        }

        public IDataResult<CustomerDto> GetByEmail(string email)
        {
            return new SuccessDataResult<CustomerDto>(_customerDao.Get(p => p.CustomerEmail == email));
        }

        public IDataResult<List<CustomerDto>> getList()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDao.GetList().ToList());
        }

        public IDataResult<List<CustomerDto>> getListByEmail(string CustomerEmail)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDao.GetList(p => p.CustomerEmail == CustomerEmail).ToList());
        }

        public IDataResult<List<CustomerDto>> getListByName(string CustomerName)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDao.GetList(p => p.CustomerName == CustomerName).ToList());
        }

        public IDataResult<List<CustomerDto>> getListByRegistryDate(DateTime CustomerRegistryDate)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDao.GetList(p => p.CustomerRegistryDate == CustomerRegistryDate).ToList());
        }

        public IDataResult<List<CustomerDto>> getListBySurname(string CustomerSurname)
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDao.GetList(p => p.CustomerSurname == CustomerSurname).ToList());
        }

        public IResult Update(CustomerDto customer)
        {
            _customerDao.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

       
        CustomerDto ICustomerService.GetByEmail(string email)
        {
            return _customerDao.Get(u => u.CustomerEmail == email);
        }
    }
}
