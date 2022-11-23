using System;
using System.Collections.Generic;
using System.Text;
using Bussiness.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<CustomerDto> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<CustomerDto> Login(UserForLoginDto userForLoginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(CustomerDto customerDto);
    }
}
