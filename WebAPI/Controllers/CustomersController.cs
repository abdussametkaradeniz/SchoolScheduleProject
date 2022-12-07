using Business.Abstract;
using Bussiness.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussiness.Constant;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        private IAuthService _authService;
        public CustomersController(ICustomerService customerService, IAuthService authService)
        {
            _customerService = customerService;
            _authService = authService;
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetList()
        {
            var result = _customerService.getList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(CustomerDto customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("DeleteCustomer")]
        public IActionResult DeleteCustomer(CustomerDto customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomerDto customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("GetCustomerById/{CustomerId}")]
        public IActionResult GetListByCustomerId(int CustomerId)
        {
            var result = _customerService.GetById(CustomerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("CustomerList")]
        public IActionResult GetCustomerList()
        {
            var result = _customerService.getList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListByEmail")]
        public IActionResult GetCustomerList(string customerEmail)
        {
            var result = _customerService.getListByEmail(customerEmail);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListByName")]
        public IActionResult GetListByName(string customerName)
        {
            var result = _customerService.getListByEmail(customerName);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListByRegistryDate")]
        public IActionResult GetListByRegistryDate(DateTime customerRegistryDate)
        {
            var result = _customerService.getListByRegistryDate(customerRegistryDate);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListBySurname")]
        public IActionResult GetListBySurname(string customerSurname)
        {
            var result = _customerService.getListBySurname(customerSurname);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExist(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("GetCustomerByEmail/{email}")]
        public ActionResult GetCustomerByEmail(string email)
        {
            var result = _customerService.GetByEmail(email);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.UserNotFound);
        }
    }
}
