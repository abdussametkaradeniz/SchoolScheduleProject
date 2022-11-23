using Bussiness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
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


        [HttpGet("GetCustomerById")]
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
    }
}
