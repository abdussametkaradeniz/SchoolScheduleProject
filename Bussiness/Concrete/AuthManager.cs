using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Bussiness.Abstract;
using Bussiness.Constant;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ICustomerService _customerService;
        private ITokenHelper _tokenHelper;

        public AuthManager(ICustomerService customerService,ITokenHelper tokenHelper)
        {
            _customerService = customerService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<CustomerDto> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var customer = new CustomerDto
            {
                CustomerEmail = userForRegisterDto.Email,
                CustomerName = userForRegisterDto.CustomerName,
                CustomerSurname = userForRegisterDto.CustomerSurname,
                CustomerRegistryDate = DateTime.Now,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                isDeleted = 0,
                CustomerAndSchool_Id = Guid.NewGuid().ToString("N")
            };
            _customerService.Add(customer);
            return new SuccessDataResult<CustomerDto>(customer, Messages.UserRegistered);
        }


        public IDataResult<CustomerDto> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _customerService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<CustomerDto>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<CustomerDto>(Messages.PasswordError);
            }

            return new SuccessDataResult<CustomerDto>(userToCheck, Messages.SuccessfulLogin);
        }


        public IResult UserExist(string email)
        {
            if (_customerService.GetByEmail(email)!=null)
            {
                return new ErrorResult(Messages.UserExist);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(CustomerDto customerDto)
        {
           
            var accessToken = _tokenHelper.createToken(customerDto);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);

        }
    }
}
